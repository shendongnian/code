    public static class Program
    {
        private static void Main(string[] args)
        {
            _startCounter = new CountdownEvent(NUM_THREADS);
            for (int i = 0; i < NUM_THREADS; ++i)
            {
                int id = i;
                Task.Factory.StartNew(() => test(id));
            }
            Console.WriteLine("Waiting for " + NUM_THREADS + " threads to start");
            _startCounter.Wait(); // Wait for all threads to have started.
            Thread.Sleep(100);
            Console.WriteLine("Threads all started. Setting signal now.");
            _signal.PulseAll();
            Thread.Sleep(1000);
            Console.WriteLine("\n{0}/{1} threads received the signal.\n\n", _signalledCount, NUM_THREADS);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        private static void test(int id)
        {
            _startCounter.Signal(); // Used so main thread knows when all threads have started.
            _signal.Wait();
            Interlocked.Increment(ref _signalledCount);
            Console.WriteLine("Task " + id + " received the signal.");
        }
        private const int NUM_THREADS = 20;
        private static readonly Signaller _signal = new Signaller();
        private static CountdownEvent _startCounter;
        private static int _signalledCount;
    }
