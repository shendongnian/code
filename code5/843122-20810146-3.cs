    public static class Queue
    {
        static int status = 0;
        public static void Process()
        {
            if (Interlocked.CompareExchange(ref status, 1, 0) == 0)
            {
                try
                {
                    //Process Queue...
                }
                finally
                {
                    Thread.VolatileWrite(ref status, 0);
                }
            }
        }
    }
