    User = Convert.ToInt32(Console.ReadLine());
    while (User >= 101 || User <= 0) 
    {
        Console.WriteLine("Sorry you input an invalid number. ");
        User = Convert.ToInt32(Console.ReadLine());
    }
