    string value = Console.ReadLine(); //Get a value from the user.
    if (int.TryParse(value, out int num))
    {
        Console.WriteLine("An integer");
    }
    else
    {
        Console.WriteLine("Not an integer");
    }
