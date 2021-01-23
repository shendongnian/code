    public class MyThreadSafeSortedSet
    {
        private SortedSet<int> _set = new SortedSet<int>(new MyComparer());
        private readonly object _locker = new object();
    
        public void Add(int value)
        {
            lock (_locker)
            {
                _set.Add(value);
            }
        }
    
        public int? Take()
        {
            lock (_locker)
            {
                if (_set.Count == 0)
                    return null;
                var item = _set.First();
                _set.Remove(item);
                return item;
            }
        }
    }
