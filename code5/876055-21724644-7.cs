    public class myComposite<T> : ICollection<T>
    {
        ObservableCollection<T> firstCollection;
        ObservableCollection<T> secondCollection;
        public myComposite(ObservableCollection<T> first, ObservableCollection<T> second)
        {
            firstCollection = first;
            secondCollection = second;
        }
        IEnumerator IEnumerable.GetEnumerator() { return new myEnum<T>(this); }
        public IEnumerator<T> GetEnumerator() { return new myEnum<T>(this); }
        public int Count { get { return firstCollection.Count + secondCollection.Count; } }
        public T this[int i]
        {
            get
            {
                if (i <= firstCollection.Count - 1) return firstCollection[i];
                else return secondCollection[i - firstCollection.Count];
            }
            set
            {
                if (i <= firstCollection.Count - 1) firstCollection[i] = value;
                else secondCollection[i - firstCollection.Count - 1] = value;
            }
        }
        public void Add(T item) { throw new NotImplementedException(); }
        public void Clear() { throw new NotImplementedException(); }
        public bool Contains(T item) { throw new NotImplementedException(); }
        public void CopyTo(T[] array, int arrayIndex) { throw new NotImplementedException(); }
        public bool IsReadOnly { get { throw new NotImplementedException(); } }
        public bool Remove(T item) { throw new NotImplementedException(); }
        private class myEnum<T> : IEnumerator<T>
        {
            public myComposite<T> _items;
            int position = -1;
            public myEnum(myComposite<T> list) { _items = list; }
            public bool MoveNext()
            {
                position++;
                return (position < _items.Count);
            }
            public void Reset() { position = -1; }
            object IEnumerator.Current { get { return Current; } }
            public T Current
            {
                get
                {
                    try { return _items[position]; }
                    catch (IndexOutOfRangeException)
                    { throw new InvalidOperationException(); }
                }
            }
            public void Dispose() { }
        }
    }
