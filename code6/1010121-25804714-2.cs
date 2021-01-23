    public class LockHelper : IDisposable
    {
        private bool needLock;
        private bool lockTaken;
        private readonly object padLock = new object();
        public LockHelper(bool needLock)
        {
            this.needLock = needLock;
            if (needLock)
                Monitor.Enter(padLock, ref  lockTaken);
        }
        public void Exit()
        {
           if (lockTaken)
           {
                Monitor.Exit(padLock);
                lockTaken = false;
           }
        }
        public void Dispose()
        {
            if (lockTaken)
                Monitor.Exit(padLock);
        }
    }
