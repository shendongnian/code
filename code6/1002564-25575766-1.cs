    int Number;
    if (!int.TryParse(Console.ReadLine(), out Number))
    {
        Console.WriteLine("Invalid number");   
    }
    TellLastNumber(Number);
