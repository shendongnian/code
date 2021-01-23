    public class MyCustomCollection : INotifyCollectionChanged
    {
        // This is what I meant by the "underlying collection", can be replaced with
        // ICollection<int> and it will still work, or even IEnumerable<int> but with some
        // code change to store the elements in an array
        private readonly IList<int> _ints;
        public MyCustomCollection()
        {
            _ints = new List<int>();
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public void AddInt(int i)
        {
            _ints.Add(i);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Reset, 
                (IList)_ints, 
                _ints.Count,
                _ints.Count - 1));
        }
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            var handler = CollectionChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
