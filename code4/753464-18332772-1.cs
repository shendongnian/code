    public class BagWithLock
    {
        // The first Id generated will be 1. If you want it to be 0, put
        // here -1 .
        private static int masterId = 0; 
        private readonly int Id = Interlocked.Increment(ref masterId);
        public static void Lock(BagWithLock bwl1, BagWithLock bwl2, Action action)
        {
            if (bwl1.Id == bwl2.Id)
            {
                // same object case
                lock (bwl1)
                {
                    action();
                }
            }
            else if (bwl1.Id < bwl2.Id)
            {
                lock (bwl1)
                {
                    lock (bwl2)
                    {
                        action();
                    }
                }
            }
            else
            {
                lock (bwl2)
                {
                    lock (bwl1)
                    {
                        action();
                    }
                }
            }
        }
    }
