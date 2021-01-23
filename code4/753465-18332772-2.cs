    public class BagWithLock
    {
        // The first Id generated will be 1. If you want it to be 0, put
        // here -1 .
        private static int masterId = 0; 
        private readonly object locker = new object();
        private readonly int id = Interlocked.Increment(ref masterId);
        public static void Lock(BagWithLock bwl1, BagWithLock bwl2, Action action)
        {
            if (bwl1.id == bwl2.id)
            {
                // same object case
                lock (bwl1.locker)
                {
                    action();
                }
            }
            else if (bwl1.id < bwl2.id)
            {
                lock (bwl1.locker)
                {
                    lock (bwl2.locker)
                    {
                        action();
                    }
                }
            }
            else
            {
                lock (bwl2.locker)
                {
                    lock (bwl1.locker)
                    {
                        action();
                    }
                }
            }
        }
    }
