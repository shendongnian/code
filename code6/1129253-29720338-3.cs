    public class MyCustomDictionary<TKey, TValue>
    {
        private readonly IEqualityComparer<TKey> _equalityComparer;
        // ... other stuff
        public MyCustomDictionary()
        {
            _equalityComparer = EqualityComparer<T>.Default;
        }
        // ... other stuff
    }
