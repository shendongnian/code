    private static void Main(string[] args)
    {
        string dialogResult = "";
        bool[] alreadyGuessed = new bool[10];
        int guesses = 0;
        Random newNumberGenerator = new Random();
        do
        {
            int number = newNumberGenerator.Next(0, 10);
            if (!alreadyGuessed[number])
            {
                guesses++;
                alreadyGuessed[number] = true;
                Console.WriteLine("Are you thinking of the number " + number.ToString() + "?")
                dialogResult = Console.ReadLine();
            }
        }
        while (dialogResult.ToUpper() != "Y" && guesses < 10);
        if (dialogResult.ToUpper() == "Y")
        {
            Console.WriteLine("I guessed the number!");
        }
        else
        {
            Console.WriteLine("No numbers left!");
        }
        Console.ReadLine();
    }
