    public class ThreadSafeList<T> : IEnumerable<T>
    {
        private List<T> _listInternal = new List<T>();
        private object _lockObj = new object();
        public void Add(T newItem)
        {
            lock(_lockObj)
            {
                _listInternal.Add(newItem);
            }
        }
        public bool Remove(T itemToRemove)
        {
            lock (_lockObj)
            {
                return _listInternal.Remove(itemToRemove);
            }
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return getCopy().GetEnumerator();                  
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return getCopy().GetEnumerator();
        }
        private List<T> getCopy()
        {
            List<T> copy = new List<T>();
            lock (_lockObj)
            {
                foreach (T item in _listInternal)
                    copy.Add(item);
            }
            return copy;
        }
    }
