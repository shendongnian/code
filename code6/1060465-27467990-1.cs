    public sealed class Signaller
    {
        public void PulseAll()
        {
            lock (_lock)
            {
                Monitor.PulseAll(_lock);
            }
        }
        public bool Wait(TimeSpan maxWaitTime)
        {
            lock (_lock)
            {
                return Monitor.Wait(_lock, maxWaitTime);
            }
        }
        private readonly object _lock = new object();
    }
