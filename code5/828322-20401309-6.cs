    public static void Acquire(this Semaphore semaphore, int permits)
    {
        lock (semaphore)
        {
            for (int i = 0; i < permits; ++i)
                semaphore.WaitOne();        
        }
    }
