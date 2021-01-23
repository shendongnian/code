    static void Main(string[] args)
    {
        var originalColor = Console.BackgroundColor;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.BackgroundColor = originalColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("The background color is red, and foreground color is green.");
        Console.ReadKey();
    }
