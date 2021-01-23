    public class SimpleCountedLock
    {
        public readonly object obj = new object();
        private int counter;
        public int Counter
        {
            get
            {
                // Guaranteed to return the last value
                return Interlocked.CompareExchange(ref counter, 0, 0);
            }
        }
        public void Enter(ref bool lockTacken)
        {
            try
            {
                Interlocked.Increment(ref counter);
                Monitor.Enter(obj, ref lockTacken);
            }
            finally
            {
                // Note that the counter could be corrupted if there is
                // an asynchronous exception
                Interlocked.Decrement(ref counter);
            }
        }
        public void Exit()
        {
            Monitor.Exit(obj);
        }
    }
