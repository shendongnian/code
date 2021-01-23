    public class ConcurrentCollection<T> : IEnumerable<T>
    {
        private readonly List<T> innerList = new List<T>();
        public void Add(T item)
        {
            lock (innerList)
            {
                innerList.Add(item);
            }
        }
        public bool TryRemove(T item)
        {
            lock (innerList)
            {
                return innerList.Remove(item);
            }
        }
        public int Count
        {
            get
            {
                lock (innerList)
                {
                    return this.innerList.Count;
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            lock (innerList)
            {
                return (IEnumerator<T>) this.innerList.ToArray().GetEnumerator();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
