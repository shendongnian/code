        public static ThreadLocal<int> _threadlocal =
            new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });
        public static void Main()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _threadlocal.Value; x++)
                {
                    Console.WriteLine("First Thread: {0}", x);
                }
            }).Start();
            new Thread(() =>
            {
                for (int x = 0; x < _threadlocal.Value; x++)
                {
                    Console.WriteLine("Second Thread: {0}", x);
                }
            }).Start();
            Console.ReadKey();
        }
