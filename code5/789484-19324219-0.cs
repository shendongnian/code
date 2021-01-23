    static char mainMenu()
    {
        ConsoleKeyInfo option = Console.ReadKey();
        if (option.Key == ConsoleKey.Escape)
        {
            Environment.Exit(0);
        }
    
        return option.KeyChar;
    }
