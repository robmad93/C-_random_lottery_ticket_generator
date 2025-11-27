using System.Globalization;
using System.Security.Cryptography;

class Program
{
    public static void Main(string[] args)
    {
        // int[] test = RandomLotteryNumberGenerator(50, 12);
        // foreach(int i in test)
        // {
        //     Console.WriteLine(i);
        // }
        int[] lottoNumbers1 = RandomLotteryNumberGenerator(50, 12);

        SaveLotteryNumbers("../resources/lottery_numbers.txt", lottoNumbers1);
        
    }
    public static void SaveLotteryNumbers(string fileLocation, int[] selection)
    {
        string textToSave = ConvertLotteryNumbersToSaveText(selection);
        File.WriteAllText(fileLocation, textToSave);
    }

    public static int[] RandomLotteryNumberGenerator(int maxNumberA, int maxNumberB)
    {
        Random random = new Random();
        int[] randomLotteryNumbers = new int [7];
        var listOfNumbers1 = new List<int> {}; // List one.
        var listOfNumbers2 = new List<int> {}; // List two.
        // int currentPick = 0;
        // First 5 numbers from 1..maxNumberA
        for (int i = 0; i < randomLotteryNumbers.Length - 2; ++i)
        {
            randomLotteryNumbers[i] = random.Next(1, maxNumberA); 
            // currentPick = randomLotteryNumbers[i]; // Redundant. Tried to check if previous index entry equalled current entry, but repeat numbers could still
            // occur since the previous entries were never retained in memory. Needed a list to collect the numbers.
            listOfNumbers1.Add(randomLotteryNumbers[i]);
            for (int j = 0; j < randomLotteryNumbers.Length - 2; ++j)
            {
                randomLotteryNumbers[j] = random.Next(1, maxNumberA); 
                while (listOfNumbers1.Contains(randomLotteryNumbers[j])) // List
                {
                   randomLotteryNumbers[j] = random.Next(1, maxNumberA); 
                   break;
                }
            }

        }
        // Console.WriteLine("Moving into numbers 6 and 7"); // Test to ensure first loop runs.
        // Last 2 numbers from 1..maxNumberB
        for (int i = 5; i < randomLotteryNumbers.Length; ++i)
        {
            randomLotteryNumbers[i] = random.Next(1, maxNumberB); 
            // currentPick = randomLotteryNumbers[i];
            listOfNumbers2.Add(randomLotteryNumbers[i]);
            for (int j = 5; j < randomLotteryNumbers.Length; ++j)
            {
                randomLotteryNumbers[j] = random.Next(1, maxNumberB);
                while (listOfNumbers2.Contains(randomLotteryNumbers[j]))
                {
                randomLotteryNumbers[j] = random.Next(1, maxNumberB); 
                   break;
                }
            }
        }
        // Console.WriteLine("finished generating numbers"); 
        // Test to ensure all numbers are generated.
        // Console.WriteLine("Entries in listOfNumbers1");
        // foreach (int i in listOfNumbers1)
        // {
        //     Console.WriteLine(i);
        // }
        // Console.WriteLine("Entries in listOfNumbers2");
        // foreach (int i in listOfNumbers2)
        // {
        //     Console.WriteLine(i);
        // }
            return randomLotteryNumbers;
    }
    public static string ConvertLotteryNumbersToSaveText(int[] selection)
    {
        string text = "Lottery numbers: ";
        for(int i = 0; i < selection.Length - 1; ++i)
        {
            text += $"{selection[i]}, ";
        }
    text += $"{selection[selection.Length - 1]}";
    return text;
    }
}