    while (true)
    {
        Console.WriteLine("BET OR PASS? (BET == 0 / PASS == 1)");
        int n;
        bool isOk = int.TryParse(Console.ReadLine(), out n);
        if(isOk && n >= 0 && n <= 1)
        {
            return n;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Invalid Ans!! try again");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
