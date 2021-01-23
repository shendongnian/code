    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);
                if (keyinfo.Modifiers.ToString() == "Control")
                {
                    if (keyinfo.Key.ToString() == "Y")
                    {
                        // Do something
                    }
                    else if (keyinfo.Key.ToString() == "Z")
                    {
                        // Do something else
                    }
                }
            }
            while (keyinfo.Key != ConsoleKey.X); // Ends the program if you press X
        }
    }
