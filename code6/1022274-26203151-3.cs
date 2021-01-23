        private static Semaphore semaphore = new Semaphore(3, 6);
        private static void Main(string[] args)
        {
            //semaphore.Release(); //openning another slot for concurreny
            semaphore.WaitOne();
            Console.WriteLine("main0");
            new Thread(() =>
            {
                semaphore.WaitOne();
                Console.WriteLine("thread0");
                semaphore.WaitOne();
                Console.WriteLine("thread1");
                Thread.Sleep(3000);
                Console.WriteLine("uncomment the release line to make main1 get in");
            }).Start();
            Thread.Sleep(1000);
            semaphore.WaitOne();
            Console.WriteLine("main1");
            Console.ReadKey();
        }
