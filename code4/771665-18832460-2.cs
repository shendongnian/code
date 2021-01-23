    public class UniqueValueDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        Dictionary<TValue, TKey> valueAsKey = new Dictionary<TValue, TKey>();
        public new void Add(TKey key, TValue value)
        {
            if (valueAsKey.ContainsKey(value))
            {
                throw new ArgumentException("value already exist");
            }
            base.Add(key, value);
            valueAsKey.Add(value, key);
        }
        public new TValue this[TKey key]
        {
            get
            {
                return base[key];
            }
            set
            {
                if (valueAsKey.ContainsKey(value))
                {
                    throw new ArgumentException("value already exist");
                }
                if (!this.ContainsKey(key))
                {
                    this.Add(key, value);
                }
                else
                {
                    base[key] = value;
                    valueAsKey[value] = key;
                }
            }
        }
    }
