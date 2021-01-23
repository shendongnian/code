        class Program
    {
        static int win_W;
        static int win_H;
        static void Main(string[] args)
        {
            Boolean running = true;
            win_W = Console.WindowWidth;
            win_H = Console.WindowHeight;
            Console.CursorVisible = false;
            int slct = 0;
            // int1 is posX, int2 is posY, string is the text you want to show as the option and boolean shows if its selected
            List<Tuple<int, int, string, Boolean>> opts = new List<Tuple<int, int, string, Boolean>>
            {
                new Tuple<int, int, string, Boolean>((win_W/2)-4, (win_H / 2) - 5, "OPTION 1", true),
                new Tuple<int, int, string, Boolean>((win_W/2)-4, (win_H / 2) - 4, "OPTION 2", false),
                new Tuple<int, int, string, Boolean>((win_W/2)-4, (win_H / 2) - 3, "OPTION 3", false),
            };
            while (running == true)
            {
                foreach (Tuple<int,int, string, Boolean> tupe in opts)
                {
                    if (tupe.Item4 == true)
                    {
                        //sets the variable 'slct' to be equal to the index of the tuple value with the true value 
                        slct = opts.FindIndex(t => t.Item3 == tupe.Item3);
                        Console.SetCursorPosition(tupe.Item1, tupe.Item2);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(tupe.Item3);
                    }
                    else if (tupe.Item4 == false)
                    {
                        Console.SetCursorPosition(tupe.Item1, tupe.Item2);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(tupe.Item3);
                    }
                }
                //Weird glitch when you take this out
                Console.SetCursorPosition(opts[2].Item1 + 1, opts[2].Item2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("");
                //A little question mark appears on the bottom option when you press escape 
                //And when you go from option 3 to option 2 it leaves one block to the right highlighted
                string inp = Console.ReadKey().Key.ToString();
                if (inp == "UpArrow" && slct > 0)
                {
                    opts[slct] = new Tuple<int, int, string, bool>(opts[slct].Item1, opts[slct].Item2, opts[slct].Item3, false);
                    slct -= 1;
                    opts[slct] = new Tuple<int, int, string, bool>(opts[slct].Item1, opts[slct].Item2, opts[slct].Item3, true);
                }
                else if (inp == "DownArrow" && slct < 2)
                {
                    opts[slct] = new Tuple<int, int, string, bool>(opts[slct].Item1, opts[slct].Item2, opts[slct].Item3, false);
                    slct += 1;
                    opts[slct] = new Tuple<int, int, string, bool>(opts[slct].Item1, opts[slct].Item2, opts[slct].Item3, true);
                }
            }
        }
    }
