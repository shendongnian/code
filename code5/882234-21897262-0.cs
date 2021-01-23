    class Program
    {
        static List<string> output = new List<string>();
        static int maxlines = 5;
        static void Foo(string s)
        {
            // echo
            output.Add(s);
            while (output.Count>maxlines)
            {
                output.RemoveAt(0);
            }
        }
        static void Main(string[] args)
        {
            string s = "";
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    char c = Console.ReadKey(true).KeyChar;
                    switch (c)
                    {
                        case '\r': Foo(s); s = ""; break;
                        case '\b': if (s.Length > 0) { s = s.Remove(s.Length - 1); } break;
                        default: s += c; break;
                    }
                    // some clearing
                    Console.SetCursorPosition(Console.WindowLeft, 6);
                    Console.Write("                                                                 ");
                    // and write current "buffer"
                    Console.SetCursorPosition(Console.WindowLeft, 6);
                    Console.Write(s);
                }
                // now lets handle our "output stream"
                for (int i = 0; i < Math.Min(maxlines, output.Count); i++)
                {
                    Console.SetCursorPosition(Console.WindowLeft, i);
                    Console.Write(output[i].PadRight(32));
                }
            }
        }
    }
