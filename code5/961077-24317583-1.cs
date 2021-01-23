        static void Main(string[] args)
        {
            Semaphore s = new Semaphore(1, 2);
            Task.Run(() =>
            {
                s.WaitOne();
                Thread.Sleep(5000);
                Console.WriteLine("Yay!");
                s.Release();
            });
            Thread.Sleep(100);
            s.WaitOne();
            Console.WriteLine("Done");
            Console.ReadKey(true);
        }
