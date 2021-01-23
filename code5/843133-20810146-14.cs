    public static class Queue
    {
        static volatile object locker = new Object();
        public static void Process()
        {
            bool lockWasTaken = false;
            try
            {
                if (Monitor.TryEnter(locker))
                {
                    lockWasTaken = true;
                    //Process Queue...
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Monitor.Exit(locker);
                }
            }
        }
    }
