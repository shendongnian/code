    public class UniqueValueDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new void Add(TKey key, TValue value)
        {
            if (this.ContainsValue(value))
            {
                throw new ArgumentException("value already exist");
            }
            base.Add(key, value);
        }
        public new TValue this[TKey key]
        {
            get
            {
                return base[key];
            }
            set
            {
                if (this.ContainsValue(value))
                {
                    throw new ArgumentException("value already exist");
                }
                base[key] = value;
            }
        }
    }
