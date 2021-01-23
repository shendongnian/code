    static void Main(string[] args)
        {
            var originalColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The BackgroundColor is " + Console.BackgroundColor.ToString() + " and the ForegroundColor is " + Console.ForegroundColor.ToString());
            Console.ReadKey();
        }
