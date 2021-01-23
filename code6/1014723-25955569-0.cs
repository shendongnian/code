    class TypeMyClassList : IList<Type>
    {
        private readonly List<Type> _list = new List<Type>();
        private bool CheckType(Type type)
        {
            return type.IsSubclassOf(typeof (MyClass)) || typeof (MyClass) == type;
        }
        public IEnumerator<Type> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(Type item)
        {
            if (CheckType(item))
                _list.Add(item);
            else
                throw new InvalidOperationException("You can't add other types than derived from A");
        }
        public void Clear()
        {
            _list.Clear();
        }
        public bool Contains(Type item)
        {
            return _list.Contains(item);
        }
        public void CopyTo(Type[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
        public bool Remove(Type item)
        {
            return _list.Remove(item);
        }
        public int Count
        {
            get { return _list.Count; }
        }
        public bool IsReadOnly { get { return false; } }
        public int IndexOf(Type item)
        {
            return _list.IndexOf(item);
        }
        public void Insert(int index, Type item)
        {
            if (!CheckType(item))
                throw new InvalidOperationException("You can't insert other types than derived from A");
            _list.Add(item);
        }
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
        public Type this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                Insert(index, value);
            }
        }
    }
