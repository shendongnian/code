    public class Example
    {
        private static int count = 10;
        private static int i = 0;
        private static AutoResetEvent firstEvent = new AutoResetEvent(true);
        private static AutoResetEvent secondEvent = new AutoResetEvent(false);
        private static void Run1(object o)
        {
            string s = o as string;
            while (true)
            {
                firstEvent.WaitOne();
                Console.WriteLine("Hello from thread number: " + Thread.CurrentThread.ManagedThreadId + " -> " + s);
                secondEvent.Set();
                if (Interlocked.Increment(ref i) > count)
                    break;
            }
        }
        private static void Run2(object o)
        {
            string s = o as string;
            while (true)
            {
                secondEvent.WaitOne();
                Console.WriteLine("Hello from thread number: " + Thread.CurrentThread.ManagedThreadId + " -> " + s);
                firstEvent.Set();
                if (Interlocked.Increment(ref i) > count)
                    break;
            }
        }
        static void Main()
        {
            Thread t1 = new Thread(Run1);
            Thread t2 = new Thread(Run2);
            t1.Start("x");
            t2.Start("+");
        }
    }
