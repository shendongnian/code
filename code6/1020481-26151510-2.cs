     static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            bool c;
            for (int i = 0; i < 1000000; i++)
            {
                c = Properties.Settings.Default.MyBool;
            }
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
            Console.ReadLine();
        }
