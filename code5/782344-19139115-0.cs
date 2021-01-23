    public class MyWorkGenerator
    {
        ConcurrentQueue<object> _queuedItems = new ConcurrentQueue<object>();
        private object _lock = new object();
        public void Produce()
        {
            while (true)
            {
                _queuedItems.Enqueue(new object());
                Monitor.Pulse(_lock);
            }
        }
        public object Consume(TimeSpan maxWaitTime)
        {
            if (!Monitor.Wait(_lock, maxWaitTime))
                return null;
            object workItem;
            if (_queuedItems.TryDequeue(out workItem))
            {
                return workItem;
            }
            return null;
        }
    }
