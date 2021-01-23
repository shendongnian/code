    class Pool<T> where T : class
    {
        private static readonly object m_SyncRoot = new object();
        private readonly Func<T> m_FactoryMethod;
        private List<T> m_PoolItems = new List<T>();
        public Pool(Func<T> factoryMethod)
        {
            m_FactoryMethod = factoryMethod;
        }
        public PoolItem<T> Get()
        {
            T target = null;
            lock (m_SyncRoot)
            {
                if (m_PoolItems.Count > 0)
                {
                    target = m_PoolItems[0];
                    m_PoolItems.RemoveAt(0);
                }
            }
            if (target == null)
                target = m_FactoryMethod();
            var wrapper = new PoolItem<T>(target);
            wrapper.Disposed += wrapper_Disposed;
            return wrapper;
        }
        void wrapper_Disposed(object sender, EventArgs e)
        {
            var wrapper = sender as PoolItem<T>;
            lock (m_SyncRoot)
            {
                m_PoolItems.Add(wrapper.WrappedObject);
            }
        }
    }
