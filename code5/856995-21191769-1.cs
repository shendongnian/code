    public class ThreadSafeQueue<T>
    {
        private readonly object syncLock = new object();
        private readonly Queue<T> innerQueue = new Queue<T>();
        public void Enqueue(T item)
        {
            lock (syncLock)
                innerQueue.Enqueue(item);
        }
        public bool TryDequeue(out T item)
        {
            lock (syncLock)
            {
                if (innerQueue.Count == 0)
                {
                    item = default(T);
                    return false;
                }
                item = innerQueue.Dequeue();
                return true;
            }
        }
    }
