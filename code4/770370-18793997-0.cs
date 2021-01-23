    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dict;
        public IEqualityComparer<TKey> Comparer
        {
            get
            {
                return _dict.Comparer;
            }
            set
            {
                _dict = new Dictionary<TKey, TValue>(_dict, value);
            }
        }
        // constructors and IDictionary implementations, mirroring _dict
    }
