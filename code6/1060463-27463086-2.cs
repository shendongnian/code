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
                Thread.Sleep(500);
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
        private volatile object lockObject = new object();
        public ReleasingAutoResetEvent()
        {
            Monitor.Enter(this.lockObject);
        }
        public void Set()
        {
            object objectToSignal = this.lockObject;
            object objectToLock = new object();
            Monitor.Enter(objectToLock);
            this.lockObject = objectToLock;
            Monitor.Exit(objectToSignal);
        }
        public void WaitOne()
        {
            object objectToMonitor = this.lockObject;
            Monitor.Enter(objectToMonitor);
            Monitor.Exit(objectToMonitor);
        }
        public bool WaitOne(int millisecondsTimeout)
        {
            object objectToMonitor = this.lockObject;
            bool succeeded = Monitor.TryEnter(objectToMonitor, millisecondsTimeout);
            if (succeeded)
            {
                Monitor.Exit(objectToMonitor);
            }
            return succeeded;
        }
        public bool WaitOne(TimeSpan timeout)
        {
            object objectToMonitor = this.lockObject;
            bool succeeded = Monitor.TryEnter(objectToMonitor, timeout);
            if (succeeded)
            {
                Monitor.Exit(objectToMonitor);
            }
            return succeeded;
        }
        public void Dispose()
        {
            Monitor.Exit(this.lockObject);
        }
    }
