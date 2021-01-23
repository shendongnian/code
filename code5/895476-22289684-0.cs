    //...
    int a = 0;
    //Capture a value for a, and range check it
    while (a < 10 || a > 50)
    {
        Console.WriteLine("Give me a number for (a)");
        a = Convert.ToInt32(Console.ReadLine());
    }
    int b = 0;
    //Capture a value for b, and range check it
    while (b < 10 || b > 50)
    {
        Console.WriteLine("Give me a number for (b)");
        b = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine("{0}", a + b);
    Console.ReadKey();
    //...
