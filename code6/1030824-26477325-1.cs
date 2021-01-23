    public class TrueReadOnlyCollection<T> : ICollection<T>, IReadOnlyCollection<T>
    {
        private ICollection<T> _original;
        public TrueReadOnlyCollection(ICollection<T> original)
        {
            _original = original;
        }
        public void Add(T item)
        {
            throw new NotSupportedException();
        }
        public void Clear()
        {
            throw new NotSupportedException();
        }
        public bool Contains(T item)
        {
            return _original.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            _original.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return _original.Count; }
        }
        public bool IsReadOnly
        {
            get { return true; }
        }
        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T t in _original)
            {
                yield return t;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
