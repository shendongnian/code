    class ConstraintHashTable<TKey, TValue> // Implement all the good interfaces
    {
        private HashSet<Type> AllowedTypes;
        private Dictionary<TKey, TValue> Dictionary;
        public TValue this[TKey key]
        {
            get
            {
                return this.Dictionary[key];
            }
        }
        public ConstraintHashTable(HashSet<Type> allowedTypes)
        {
            this.AllowedTypes =
                allowedTypes == null ? new HashSet<Type>() : allowedTypes;
            this.Dictionary = new Dictionary<TKey, TValue>();
        }
        public void Add(TKey key, TValue value)
        {
            if (this.AllowedTypes.Contains(value.GetType()) == false)
            {
                throw new ArgumentException(
                    "I don't accept values of type: " + value.GetType().FullName + ".");
            }
            this.Dictionary.Add(key, value);
        }
    }
