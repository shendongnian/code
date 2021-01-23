    class Program
    {
        private static Random random;
        private static int refCount;
        private static object syncObject = new object();
        private static AutoResetEvent resetEvent = new AutoResetEvent(true);
        static void Main(string[] args)
        {
            random = new Random();
            new Thread(() => DoSomething(false)).Start();
            new Thread(() => DoSomething(false)).Start();
            new Thread(() => DoSomething(true)).Start();
            new Thread(() => DoSomething(false)).Start();
            new Thread(() => DoSomething(false)).Start();
            Console.Read();
        }
        private static void DoSomething(bool singleThread)
        {
            if (singleThread)
            {
                lock (syncObject)
                {
                    ++refCount;
                    // Inside this lock, no new thread can get to the parameterless DoSomething() method.  
                    // However, existing threads can continue to do their work, and notify this thread that they have finished by signalling using the resetEvent.
                    while (refCount > 1)
                        resetEvent.WaitOne();
                    Console.WriteLine("Starting exclusive task.");
                    DoSomething();
                    Console.WriteLine("Finished exclusive task.");
                }
            }
            else
            {
                lock (syncObject)
                    ++refCount;
                DoSomething();
            }
            --refCount;
            resetEvent.Set();
        }
        private static void DoSomething()
        {
            Console.WriteLine("Starting task on thread {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Finished task on thread {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
