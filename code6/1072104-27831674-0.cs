    class Program
    {
        private static Timer timer;
        private static ManualResetEvent mre = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            timer = new Timer(TimerCallback, null, 0, (int)TimeSpan.FromMinutes(15).TotalMilliseconds);
            mre.WaitOne();
        }
        private static void TimerCallback(object state)
        {
            // ... do something in here ...
            Console.WriteLine("Something done at " + DateTime.Now.ToString());
        }
    }
