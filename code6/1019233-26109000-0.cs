        static void Main(string[] args)
        {
            printMenu(0);
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key != ConsoleKey.DownArrow && key != ConsoleKey.UpArrow)
                    continue;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (pointerLocation < stringArray.Length - 1)
                        {
                            pointerLocation += 1;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (pointerLocation > 0)
                        {
                            pointerLocation -= 1;
                        }
                        break;
                }
                Console.Clear();
                printMenu(pointerLocation);
            }
        }
