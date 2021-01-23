    public class MyEnumerable : EnumerateBase<int> { }
    public class EnumerateBase<T> where T :  struct 
    {
        private IEnumerable<T> _en;
        object _lock = new Object();
        public void SetEnumerable(params T[] value)
        {
            _en = value;
        }
        public void Enumerate()
        {
            IEnumerable<T> en = null;
            lock (_lock)
            {
                en = _en;
                _en = new List<T>();
                // ...
            }
            foreach (var i in en) { /* ... */ }
        }
    }
