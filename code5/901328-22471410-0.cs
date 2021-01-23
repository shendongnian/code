    var input = Console.Readline();
    double test value;
    while(!double.TryParse(input, out double))
    {
        Console.WriteLine("Invalid input. Please try again...");
        input = Console.ReadLine();
    }
