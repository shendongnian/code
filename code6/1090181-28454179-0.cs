    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        public static class Program
        {
            public static void Main()
            {
                using (Barrier barrier = new Barrier(3))
                using (AutoResetEvent t2 = new AutoResetEvent(false))
                using (AutoResetEvent t3 = new AutoResetEvent(false))
                {
                    Parallel.Invoke
                    (
                        () => worker(1, barrier, null, t2),
                        () => worker(2, barrier, t2, t3),
                        () => worker(3, barrier, t3, null)
                    );
                }
            }
            private static void worker(int threadId, Barrier barrier, AutoResetEvent thisThreadEvent, AutoResetEvent nextThreadEvent)
            {
                Random rng = new Random(threadId);
                for (int i = 0; i < 1000; ++i)
                {
                    doSomething(threadId, rng); // We don't care what order threads execute this code.
                    barrier.SignalAndWait(); // Wait for all threads to reach this point.
                    if (thisThreadEvent != null)   // If this thread is supposed to wait for a signal
                        thisThreadEvent.WaitOne(); // before proceeding, then wait for it.
                    doWorkThatMustBeDoneInThreadOrder(threadId);
                    if (nextThreadEvent != null) // If this thread is supposed to raise a signal to indicate
                        nextThreadEvent.Set();   // that the next thread should proceed, then raise it.
                    barrier.SignalAndWait(); // Wait for all threads to reach this point.
                }
            }
            private static void doWorkThatMustBeDoneInThreadOrder(int threadId)
            {
                Console.WriteLine("   B" + threadId);
                Thread.Sleep(200); // Simulate work.
            }
            private static void doSomething(int threadId, Random rng)
            {
                for (int i = 0; i < 5; ++i)
                {
                    Thread.Sleep(rng.Next(50)); // Simulate indeterminate amount of work.
                    Console.WriteLine("A" + threadId);
                }
            }
        }
    }
