    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);
                if (keyinfo.Modifiers == ConsoleModifiers.Control)
                {
                    if (keyinfo.Key == ConsoleKey.Y)
                    {
                        // Do something
                    }
                    else if (keyinfo.Key == ConsoleKey.Z)
                    {
                        // Do something else
                    }
                }
            }
            while (keyinfo.Key != ConsoleKey.X); // Ends the program if you press X
        }
    }
