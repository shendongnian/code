    class Loop
        : IDisposable
    {
        IScheduler scheduler = new EventLoopScheduler();
        MultipleAssignmentDisposable stopper = new MultipleAssignmentDisposable();
        public Loop()
        {
            Next();
        }
        void Next()
        {
            if (!stopper.IsDisposed)
                stopper.Disposable = scheduler.Schedule(Handler);
        }
        void Handler()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Handler: {0}", Thread.CurrentThread.ManagedThreadId);
            Next();
        }
        public void Notify()
        {
            scheduler.Schedule(() =>
            {
                Console.WriteLine("Notify: {0}", Thread.CurrentThread.ManagedThreadId);
            });
        }
        public void Dispose()
        {
            stopper.Dispose();
        }
    }
    static void Main(string[] args)
    {
        using (var l = new Loop())
        {
            Console.WriteLine("Press 'q' to quit.");
            while (Console.ReadKey().Key != ConsoleKey.Q)
                l.Notify();
        }
    }
