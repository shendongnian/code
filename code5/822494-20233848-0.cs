    private static void Drawing(int x, int y, string symbol)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(symbol);
    }
    private static void DeletingLastDraw(int x, int y)
    {
        Drawing(x, y, " ");
    }
