    while (guess < 1 || guess > 4)
    {
        Console.Write("Enter a number between 1 and 4: ");
        guess = Int32.Parse(Console.ReadLine());
    }
