    private static object consoleLock = new object();
    private static void Drawing(int x, int y, string symbol)
    {
        lock (consoleLock)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
