    int intValue;
    string input = Console.ReadLine();
    if(Int32.TryParse(input, out intValue))
        Console.WriteLine("Correct number typed");
    else
        Console.WriteLine("The input is not a valid integer");
