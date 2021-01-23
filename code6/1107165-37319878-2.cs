    class FunctionDictionary
    {
        /// <summary>
        /// Internal dictionary that will store the function delegates as Object.
        /// </summary>
        private Dictionary<string, Object> m_Map = new Dictionary<string, object>();
        /// <summary>
        /// Add method to dictionary for specified key. Encapsulated method has no parameters.
        /// </summary>
        public void Add<TResult>(string key, Func<TResult> function) 
        {
            m_Map.Add(key, function);
        }
        /// <summary>
        /// Get method for specified key. Encapsulated method has no parameters.
        /// </summary>
        public Func<TResult> Function<TResult>(string key)
        {
            return (Func<TResult>)m_Map[key];
        }
        /// <summary>
        /// Add method to dictionary for specified key. Encapsulated method has one parameters.
        /// </summary>
        public void Add<T1, TResult>(string key, Func<T1, TResult> function)
        {
            m_Map.Add(key, function);
        }
        /// <summary>
        /// Get method for specified key. Encapsulated method has one parameters.
        /// </summary>
        public Func<T, TResult> Function<T, TResult>(string key)
        {
            return (Func<T, TResult>)m_Map[key];
        }
        public void Add<T1, T2, TResult>(string key, Func<T1, T2, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, TResult>(string key, Func<T1, T2, T3, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, TResult>(string key, Func<T1, T2, T3, T4, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, TResult>(string key, Func<T1, T2, T3, T4, T5, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, T6, TResult>(string key, Func<T1, T2, T3, T4, T5, T6, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, T6, T7, TResult>(string key, Func<T1, T2, T3, T4, T5, T6, T7, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(string key, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(string key, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(string key, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(string key, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(string key, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(string key, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(string key, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(string key, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> function)
        {
            m_Map.Add(key, function);
        }
        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(string key, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function)
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
        public Func<T1, T2, TResult> Function<T1, T2, TResult>(string key)
        {
            return (Func<T1, T2, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, TResult> Function<T1, T2, T3, TResult>(string key)
        {
            return (Func<T1, T2, T3, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, TResult> Function<T1, T2, T3, T4, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, TResult> Function<T1, T2, T3, T4, T5, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, T6, TResult> Function<T1, T2, T3, T4, T5, T6, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, T6, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, T6, T7, TResult> Function<T1, T2, T3, T4, T5, T6, T7, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, T6, T7, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Function<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>)m_Map[key];
        }
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(string key)
        {
            return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>)m_Map[key];
        }
    }
