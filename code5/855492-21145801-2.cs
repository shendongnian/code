    static void Main(string[] args)
    {
     var originalColor = Console.BackgroundColor;
     Console.BackgroundColor = ConsoleColor.Red;
     Console.Write("The background color is red. ");
     Console.BackgroundColor = originalColor;
     Console.ForegroundColor = ConsoleColor.Green;
     Console.Write("The foreground color is green");
     Console.ReadKey();
    }
