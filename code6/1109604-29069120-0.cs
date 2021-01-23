    class SubsetList<T> : IReadOnlyList<T>
    {
        private IReadOnlyList<T> _list;
        private int _offset = offset;
        private int _length = length;
        public SubsetList(IReadOnlyList<T> list, int offset, int length)
        {
             _list = list;
             _offset = offset;
             _length = length;
        }
        public int Count { get { return _length; } }
        public T this[int index]
        {
            get { return _list[offset + index]; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _offset; i < _offset + _length; i++)
            {
                yield return _list[i];
            }
        }
        private IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
