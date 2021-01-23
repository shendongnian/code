        public static string ReadHiddenFromConsole()
        {
            var word = new StringBuilder();
            while (true)
            {
                var i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (i.Key == ConsoleKey.Backspace)
                {
                    if (word.Length > 0)
                    {
                        word.Remove(word.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    word.Append(i.KeyChar);
                    Console.Write("*");
                }
            }
            return word.ToString();
        }
