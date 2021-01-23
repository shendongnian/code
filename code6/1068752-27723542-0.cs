    public static void RemoveCurrentConsoleLine()
    {
        int currentCursorLine = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, currentCursorLine);
    }
    Console.WriteLine("Top 1 Line");
    Console.WriteLine("Top 2 Line");
    Console.WriteLine("Top 3 Line");
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    ClearCurrentConsoleLine();
