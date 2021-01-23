    public static class Example
    {
        private static volatile bool stopRunning;
        private static ReleasingAutoResetEvent myEvent;
        public static void RunExample()
        {
            using (Example.myEvent = new ReleasingAutoResetEvent())
            {
                WaitCallback work = new WaitCallback(WaitThread);
                for (int i = 0; i < 5; ++i)
                {
                    ThreadPool.QueueUserWorkItem(work, i.ToString());
                }
                for (int i = 0; i < 3; ++i)
                {
                    Example.myEvent.Set();
                    Thread.Sleep(5000);
                }
                Example.stopRunning = true;
                Example.myEvent.Set();
            }
        }
        private static void WaitThread(object state)
        {
            while (!Example.stopRunning)
            {
                Example.myEvent.WaitOne();
                Console.WriteLine("Thread {0} is released!", state);
            }
        }
    }
    public sealed class ReleasingAutoResetEvent : IDisposable
    {
        private volatile ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        public void Set()
        {
            ManualResetEvent eventToSet = this.manualResetEvent;
            this.manualResetEvent = new ManualResetEvent(false);
            eventToSet.Set();
            eventToSet.Dispose();
        }
        public bool WaitOne()
        {
            return this.manualResetEvent.WaitOne();
        }
        public bool WaitOne(int millisecondsTimeout)
        {
            return this.manualResetEvent.WaitOne(millisecondsTimeout);
        }
        public bool WaitOne(TimeSpan timeout)
        {
            return this.manualResetEvent.WaitOne(timeout);
        }
        public void Dispose()
        {
            this.manualResetEvent.Dispose();
        }
    }
