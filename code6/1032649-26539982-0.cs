    Console.WriteLine("What is the Temperature in Fahrenheit?")
    string input = Console.ReadLine ();
    
    while (input != "")
    {
        double tt = double.Parse (input);
        double cc = (tt-32)*5/9;
        Console.WriteLine(cc + " is the temperature in Celsius");
        Console.WriteLine("What is the Temperature in Fahrenheit?")
        input = Console.ReadLine ();
    }
