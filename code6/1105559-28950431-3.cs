    public static void PrintColor(ColoredString str)
    {
        var prevColor = Console.BackgroundColor;
        Console.BackgroundColor = str.Color;
        Console.Write(str.Content);
        Console.BackgroundColor = prevColor;
    }
