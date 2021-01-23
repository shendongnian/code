    static void Main(string[] args)
        {
            bool test = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (long i = 0; i < 100000000; i++)
            {
                if (!test)
                    test = true;
            }
            sw.Stop();
            
            Console.WriteLine(sw.ElapsedMilliseconds + ". Hi, I'm just using test  somehow:" + test);
            sw.Reset();
            bool test2 = false;
            sw.Start();
            for (long i = 0; i < 100000000; i++)
            {
                    test2 = true;
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds + ". Hi, I'm just using test2 somehow:" + test2);
            Console.ReadKey();
        }
