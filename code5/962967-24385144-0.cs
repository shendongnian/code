    class MyCollection<T> : IEnumerable<T>
    {
        private List<T> _list = new List<T>();
        private Receiver _receiver;
        public MyCollection()
        {
            _receiver = receiver;
        }
        public void Add(T item)
        {
            _list.Add(item);
        }
        public void RemoveAndNotify(T item)
        {
            _list.Remove(item);
            _receiver.Notify(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
