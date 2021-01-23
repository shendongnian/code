        private static Semaphore semaphore = new Semaphore(3, 6);
        private static void Main(string[] args)
        {
            semaphore.WaitOne();
            Console.WriteLine("main");
            Thread.Sleep(1000);
            new Thread(() =>
            {
                semaphore.WaitOne();
                Console.WriteLine("t");
                semaphore.WaitOne();
                Console.WriteLine("t");
            }).Start();
            semaphore.WaitOne();
            Console.WriteLine("main");
            Console.ReadKey();
        }
