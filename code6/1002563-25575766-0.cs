    int Number = 0;
    try
    {
        int Number = Convert.ToInt32(Console.ReadLine());
    }
    catch ( OverflowException )
    {
        Console.WriteLine("Number to big");
    }
    
    TellLastNumber(Number);
