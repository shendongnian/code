    Console.Write("Type x: ");
    var input = Console.ReadLine();
    double value;
            
    while (!double.TryParse(input, NumberStyles.Any,
        CultureInfo.InvariantCulture, out value))
    {
        Console.Write("{0} is not a double. Please try again: ");
        input = Console.ReadLine();
    }
    Console.WriteLine("Thank you! {0} is a double", value);
