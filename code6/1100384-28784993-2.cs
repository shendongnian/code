    public sealed class SimpleCountedLock
    {
        private readonly object obj = new object();
        private int counter;
        public int Counter
        {
            get
            {
                // Guaranteed to return the last value
                return Interlocked.CompareExchange(ref counter, 0, 0);
            }
        }
        public void Enter(ref bool lockTaken)
        {
            int cnt = int.MinValue;
            try
            {
                cnt = Interlocked.Increment(ref counter);
                Monitor.Enter(obj, ref lockTaken);
            }
            finally
            {
                // There could be an asynchronous exception (Thread.Abort for example)
                // between the try and the Interlocked.Increment .
                // Here we check if the Increment was done
                if (cnt != int.MinValue)
                {
                    Interlocked.Decrement(ref counter);
                }
            }
        }
        public void Exit()
        {
            Monitor.Exit(obj);
        }
    }
