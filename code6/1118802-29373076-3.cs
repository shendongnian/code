    public class BlockingProducerConsumerQueue<T>
    {
        private SemaphoreSlim m_NeedKeys = new SemaphoreSlim(0);
        private SemaphoreSlim m_HasKeys = new SemaphoreSlim(0);
        private ConcurrentQueue<ConsoleKeyInfo> m_KeysQueue = new ConcurrentQueue<ConsoleKeyInfo>();
        public void EnqueueIfRequired(ConsoleKeyInfo keyInfo)
        {
            if (!this.m_NeedKeys.Wait(0))
                return;
            this.m_KeysQueue.Enqueue(keyInfo);
            this.m_HasKeys.Release();
        }
        public ConsoleKeyInfo Dequeue()
        {
            this.m_NeedKeys.Release(1);
            this.m_HasKeys.Wait();
            ConsoleKeyInfo keyInfo;
            if (!this.m_KeysQueue.TryDequeue(out keyInfo))
                throw new InvalidOperationException("Invalid state encountered");
            return keyInfo;
        }
    }
