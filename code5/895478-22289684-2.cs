    int a = 0;
    //Get a value for a
    while (true)
    {
        Console.WriteLine("Give me a number for (a)");
        a = Convert.ToInt32(Console.ReadLine());
        //Range check and exit if valid
        if (a >= 10 && a <= 50)
            break;
        Console.WriteLine("That number is too large");
    }
    int b = 0;
    //Get a value for b
    while (true)
    {
        Console.WriteLine("Give me a number for (b)");
        b = Convert.ToInt32(Console.ReadLine());
        //Range check and exit if valid
        if (b >= 10 && b <= 50)
            break;
        Console.WriteLine("That number is too large");
    }
    Console.WriteLine("{0}", a + b);
    Console.ReadKey();
