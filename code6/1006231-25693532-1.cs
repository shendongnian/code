    public class FixedParallelismQueue
    {
        private SemaphoreSlim semaphore;
        public FixedParallelismQueue(int maxDegreesOfParallelism)
        {
            semaphore = new SemaphoreSlim(maxDegreesOfParallelism);
        }
    
        public async Task<T> Enqueue<T>(Func<Task<T>> taskGenerator)
        {
            await semaphore.WaitAsync();
            try
            {
                return await taskGenerator();
            }
            finally
            {
                semaphore.Release();
            }
        }
        public async Task Enqueue(Func<Task> taskGenerator)
        {
            await semaphore.WaitAsync();
            try
            {
                await taskGenerator();
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
