    class RestrictedTypeDictionary<TRestriction>
    {
        public RestrictedTypeDictionary()
        {
            this.internalDictionary = new Dictionary<int, Type>();
        }
    
        private readonly Dictionary<int, Type> internalDictionary;
    
        public void Add(int key, Type value)
        {
            if (!typeof(TRestriction).IsAssignableFrom(value))  // <- that's the important bit
            {
                throw new ArgumentOutOfRangeException("value");
            }
            internalDictionary.Add(key, value);
        }
    
        public Type this[int key]
        {
            get
            {
                return internalDictionary[key];
            }
        }
        …
    }
