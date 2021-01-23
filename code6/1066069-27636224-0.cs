    class Test
    {
        private struct Key
        {
            public string Key1 { get; set; }
            public string Key2 { get; set; }
            public Key(string key1, string key2) 
                : this()
            {
                Key1 = key1;
                Key2 = key2;
            }
        }
        private readonly Dictionary<Key, object> _dictionary = new Dictionary<Key, object>();
        public object this[string key1, string key2]
        {
            get { return _dictionary[new Key(key1, key2)]; }
            set { _dictionary[new Key(key1, key2)] = value; }
        }
    }
