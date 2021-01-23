    public class BagWithLock
    {
        private static int masterId = 0;
        private int Id = Interlocked.Increment(ref masterId);
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
