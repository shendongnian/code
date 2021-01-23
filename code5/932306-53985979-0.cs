    public class FifoSemaphore
    {
        private readonly object lockObj = new object();
        private List<Semaphore> WaitingQueue = new List<Semaphore>();
        private Semaphore RequestNewSemaphore()
        {
            lock (lockObj)
            {
                Semaphore newSemaphore = new Semaphore(1, 1);
                newSemaphore.WaitOne();
                return newSemaphore;
            }
        }
        #region Public Functions
        public void Release()
        {
            lock (lockObj)
            {
                WaitingQueue.RemoveAt(0);
                if (WaitingQueue.Count > 0)
                {
                    WaitingQueue[0].Release();
                }
            }
        }
        public void WaitOne()
        {
            Semaphore semaphore = RequestNewSemaphore();
            lock (lockObj)
            {
                WaitingQueue.Add(semaphore);
                semaphore.Release();
                if(WaitingQueue.Count > 1)
                {
                    semaphore.WaitOne();
                }
            }
            semaphore.WaitOne();
        }
        #endregion
    }
