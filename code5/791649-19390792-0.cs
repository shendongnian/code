        static void Main(string[] args)
        {
            int i = 0;
            string str;
            while (i < 1000)
            {
                str = (++i).ToString();
                Thread t = new Thread((s) => Console.WriteLine(s));
                t.Start(str);
            }
            Console.ReadLine();
        }
