    class FunctionDictionary
    {
        private Dictionary<string, Object> m_Map = new Dictionary<string, object>();
        public void Add<T>(string key, T function) 
        {
            m_Map.Add(key, function);
        }
        public Object this[string key]
        {
            get
            {
                return m_Map[key];
            }
        }
        public T Function<T>(string key)
        {
            return (T)m_Map[key];
        }
    }
