    public class MyCustomDictionary<TKey, TValue>
    {
        private static readonly Func<TKey, TKey, bool> _equalityComparer;
        // ... other stuff
        static MyCustomDictionary()
        {
            if (typeof(TKey).IsClass)
                _equalityComparer = (lhs, rhs) => Object.ReferenceEquals(lhs, rhs)
            else
                _equalityComparer = (lhs, rhs) => lhs.Equals(rhs);
        }
        // ... other stuff
    }
