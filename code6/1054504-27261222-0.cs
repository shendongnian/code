    public class RememberOrderList<T> : IList<T>
    {
        private List<T> _inner = new List<T>();
        public int IndexOf(T item) { return _inner.IndexOf(item); }
        public void RemoveAt(int index) { _inner.RemoveAt(index); }
        public T this[int index] { get { return _inner[index]; } set { _inner[index] = value; } }
        public void Clear() { _inner.Clear(); }
        public bool Contains(T item) { return _inner.Contains(item); }
        public void CopyTo(T[] array, int arrayIndex) { _inner.CopyTo(array, arrayIndex); }
        public int Count { get { return _inner.Count; } }
        public bool IsReadOnly { get { return ((ICollection<T>)_inner).IsReadOnly; } }
        public bool Remove(T item) { return _inner.Remove(item); }
        public IEnumerator<T> GetEnumerator() { return _inner.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return _inner.GetEnumerator(); }
