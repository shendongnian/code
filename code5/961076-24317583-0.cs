        static void Main(string[] args)
        {
            int x = 1;
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Yay!");
                x = 0;
            });
            while (x != 0) { Thread.Yield(); }
            Console.WriteLine("Done");
            Console.ReadKey(true);
        }
