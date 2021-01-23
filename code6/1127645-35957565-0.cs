        static int readIndex()
        {
            string num = string.Empty;
            ConsoleKeyInfo cr;
            do
            {
                cr = Console.ReadKey(true);
                int n;
                if (int.TryParse(cr.KeyChar.ToString(), out n))
                {
                    num += cr.KeyChar.ToString();
                    Console.Write(cr.KeyChar.ToString());
                }
                else if (cr.Key == ConsoleKey.Backspace)
                {
                    if (num.Length > 0)
                    {
                        Console.Write("\b");
                        num = num.Remove(num.Length - 1);
                    }
                }
            } while (cr.Key != ConsoleKey.Enter);
            Console.Write("  ");
            return int.Parse(num);
        }
