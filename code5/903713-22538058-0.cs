    var key = Console.ReadKey(false); // this read one key without displaying it
            
    if (key.Key == ConsoleKey.D0)
    {
        return 0;
    }
    if (key.Key == ConsoleKey.D1)
    {
        return 1;
    }
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Invalid Ans!! try again");
    Console.ForegroundColor = ConsoleColor.Gray;
