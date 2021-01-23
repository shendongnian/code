    while (guess1 < 1 || guess1 > 4)
    {
        Console.Write("First Guess Lottery Number is (enter a number between 1 and 4): ");
        guess1 = Int32.Parse(Console.ReadLine());
    }
