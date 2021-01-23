        static void Main(string[] args)
        {
            string s = "33349836";
            int width = 10;
            char padding = '0';
            string s1 = s.PadLeft(width, padding);
            Console.WriteLine(s);
            Console.WriteLine(s1);
        }
