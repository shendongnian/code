    public class FiniteObjectPool<T>: IDisposable
    {
        System.Threading.AutoResetEvent m_Wait = new System.Threading.AutoResetEvent(false);
        private ConcurrentBag<T> _objects;
        public FiniteObjectPool()
        {
            _objects = new ConcurrentBag<T>();
        }
        public T GetObject()
        {
            T item;
            while(!_objects.TryTake(out item))
            {
                m_Wait.WaitOne(); //an object was not available, wait until one is
            }
            return item;
        }
        public void PutObject(T item)
        {
            _objects.Add(item);
            m_Wait.Set(); //signal a waiting thread that object may now be available
        }
        public void Dispose()
        {
            m_Wait.Dispose();
        }
    }
