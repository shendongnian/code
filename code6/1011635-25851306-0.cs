    Console.Write("Please enter your ID: ");
    int id;
    if (!int.TryParse(Console.Read(), out id)) // what should I write here?
    {
        Console.WriteLine("Only Numeric value are allowed.");
    }
    else
    {
        Console.WriteLine("My ID is {0}", id);
    }
