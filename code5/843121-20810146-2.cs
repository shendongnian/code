    public static class Queue
    {
        static volatile object locker = new Object();
        public static void Process()
        {
            if (Monitor.TryEnter(locker))
            {
                //Process Queue...
            }
        }
    }
