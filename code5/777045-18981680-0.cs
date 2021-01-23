    class Hashtable : Dictionary<object, object>
    {
        new public IDictionaryEnumerator GetEnumerator()
        {
            return new DictionaryEnumerator(base.GetEnumerator());
        }
        
        struct DictionaryEnumerator : IDictionaryEnumerator
        {
            private Enumerator _en;
            
            public DictionaryEnumerator(Dictionary<object, object>.Enumerator en)
            {
                _en = en;
            }
            
            public object Current
            {
                get
                {
                    return Entry;
                }
            }
            
            public DictionaryEntry Entry
            {
                get
                {
                    var kvp = _en.Current;
                    return new DictionaryEntry(kvp.Key, kvp.Value);
                }
            }
            
            public bool MoveNext()
            {
                bool result = _en.MoveNext();
                return result;
            }
            
            public void Reset()
            {
                throw new NotSupportedException();
            }
            
            public object Key
            {
                get
                {
                    var kvp = _en.Current;
                    return kvp.Key;
                }
            }
    
            public object Value
            {
                get
                {
                    var kvp = _en.Current;
                    return kvp.Value;
                }
            }
        }
    }
