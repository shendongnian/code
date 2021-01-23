    public static class Queue
    {
        static volatile object locker = new Object();
        public static void Process()
        {
            bool lockWasTaken = false;
            try
            {
                if (Monitor.TryEnter(_syncroot))
                {
                    lockWasTaken = true;
                    //Process Queue...
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Monitor.Exit(_syncroot);
                }
            }
        }
    }
