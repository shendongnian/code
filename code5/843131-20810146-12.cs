    public static class Queue
    {
        static int status = 0;
        public static void Process()
        {
            bool lockWasTaken = false;
            try
            {
                lockWasTaken = Interlocked.CompareExchange(ref status, 1, 0) == 0;
                if (lockWasTaken)
                {
                    //Process Queue...
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Thread.VolatileWrite(ref status, 0);
                }
            }
        }
    }
