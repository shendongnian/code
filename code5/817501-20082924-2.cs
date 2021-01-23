    public class EventThrottlerMultiThreaded
    {
        private object key = new object();
        private Func<Task> next = null;
        private bool isRunning = false;
        public void Run(Func<Task> action)
        {
            bool shouldStartRunning = false;
            lock (key)
            {
                if (isRunning)
                    next = action;
                else
                {
                    isRunning = true;
                    shouldStartRunning = true;
                }
            }
            Action<Task> continuation = null;
            continuation = task =>
            {
                Func<Task> nextCopy = null;
                lock (key)
                {
                    if (next != null)
                    {
                        nextCopy = next;
                        next = null;
                    }
                    else
                    {
                        isRunning = false;
                    }
                }
                if (nextCopy != null)
                    nextCopy().ContinueWith(continuation);
            };
            if (shouldStartRunning)
                action().ContinueWith(continuation);
        }
    }
