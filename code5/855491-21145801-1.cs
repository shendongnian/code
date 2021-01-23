    static void Main(string[] args)
    {
     var originalColor = Console.BackgroundColor;
     Console.BackgroundColor = ConsoleColor.Red;
     Console.WriteLine("The background color is red.");
     Console.BackgroundColor = originalColor;
     Console.ForegroundColor = ConsoleColor.Green;
     Console.WriteLine("The foreground color is green");
     Console.ReadKey();
    }
