    internal class Memory
    {
        public int GetData(int key)
        {
            int result;
            object locker;
                // short time lock, blocks all readers
                lock (lockObject)
                    if !m_locks.TryGetValue(result, out object locker)
                    {
                        locker = m_locks[key] = new object();
                    }
                // long time lock, but only for readers of this key during expensive op
                lock (locker)
                    if (!m_values.TryGetValue(key, out result))
                    {
                        result = m_values[key] = VeryExpensiveComputationMethod(key);
                    }
            return result;
        }
        private readonly Object lockObject = new Object();
        private Dictionary<int, int> m_values;
        private Dictionary<int, object> m_locks;
    }
