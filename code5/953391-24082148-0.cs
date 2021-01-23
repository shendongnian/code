    public class CustomList<T> : IList<T>
    {
        private IList<T> _list;
        private Boolean _isReadOnly;
        public CustomList(IList<T> source, Boolean isReadOnly)
        {
            _list = source;
            _isReadOnly = isReadOnly;
        }
        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            if (_isReadOnly == true)
            {
                throw new Exception("List is readonly. Method = Insert(int index, T item)");
            }
            _list.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            if (_isReadOnly == true)
            {
                throw new Exception("List is readonly. Method = RemoveAt(int index)");
            }
            _list.RemoveAt(index);
        }
        public T this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                if (_isReadOnly == true)
                {
                    throw new Exception("List is readonly. Property = this[int index]");
                }
                _list[index] = value;
            }
        }
        public void Add(T item)
        {
            if (_isReadOnly == true)
            {
                throw new Exception("List is readonly. Method = Add(T item)");
            }
            _list.Add(item);
        }
        public void Clear()
        {
            if (_isReadOnly == true)
            {
                throw new Exception("List is readonly. Method = Clear()");
            }
            _list.Clear();
        }
        public bool Contains(T item)
        {
            return _list.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return _list.Count; }
        }
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
        }
        public bool Remove(T item)
        {
            if (_isReadOnly == true)
            {
                throw new Exception("List is readonly. Method = Remove(T item)");
            }
            return _list.Remove(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
