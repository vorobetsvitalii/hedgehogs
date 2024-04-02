using System;

class Program
{
    static int MinMeetings(int[] population, int desiredColor)
    {
        if (population[(desiredColor + 1) % 3] == 0 && population[(desiredColor + 2) % 3] == 0) 
        { 
            return 0; // Не потрібно змінювати кольори, якщо всі вже є бажаного кольору
        }

        int unwantedColor1 = (desiredColor + 1) % 3; // Перший небажаний колір
        int unwantedColor2 = (desiredColor + 2) % 3; // Другий небажаний колір

        if(population[unwantedColor1] == 0 && population[desiredColor] == 0 || population[unwantedColor2] == 0 && population[desiredColor] == 0)
        {
            return -1;
        }

        int diff = Math.Abs(population[unwantedColor1] - population[unwantedColor2]);

        if (diff % 3 == 0)
        {
            int meets = diff / 3;
            meets += ((population[unwantedColor1] + population[unwantedColor2] + meets) / 2);
            return meets;
        }
        else
        {
            return -1;
        }
    }

    static void Main(string[] args)
    {
        int[] population = { 0, 1, 7 };
        int desiredColor = 0;

        int minMeetings = MinMeetings(population, desiredColor);
        if (minMeetings != -1)
        {
            Console.WriteLine($"Мінімальна кількість зустрічей для зміни всіх їжачків у бажаний колір: {minMeetings}");
        }
        else
        {
            Console.WriteLine("Неможливо змінити всіх їжачків у бажаний колір.");
        }
    }
}
