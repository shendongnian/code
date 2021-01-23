    public static Int32 SetInterval(ConsoleKeyInfo cki)
    {
        if (cki.Key == ConsoleKey.D1)
        {
            return 10000;
        }
        else if (cki.Key == ConsoleKey.D2)
        {
            return 20000;
        }
        else if (cki.Key == ConsoleKey.D3)
        {
            return 30000;
        }
        else if (cki.Key == ConsoleKey.D4)
        {
            return 45000;
        }
        else if (cki.Key == ConsoleKey.D5)
        {
            return 60000;
        }
        else if (cki.Key == ConsoleKey.D6)
        {
            return 120000;
        }
        else
        {
            return SetInterval(Console.ReadKey());
        }
    }
