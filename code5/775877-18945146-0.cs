    public class ThreadLock
    {
        private static readonly object myLock;
        public void LockTimeout()
        {
            // --> first thread will trigger the following code. 
            // All other threads will wait 
            // <-- HERE 
            // until the first went through 
            lock (myLock)
            {
                //... do some timeout work
            }
        }
    }
