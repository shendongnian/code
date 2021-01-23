    namespace Extentions
    {
        public static class SemaphoreExtentions
        {
        
            public static void Acquire(this Semaphore semaphore, int permits)
            {
               for (int i = 0; i < permits; ++i)
                   semaphore.WaitOne();
            }
        }
    }
