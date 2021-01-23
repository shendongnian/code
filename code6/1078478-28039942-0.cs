    public enum Type
    {
        AddItem,
        RemoveItem
    }
    
    public class DictChangedEventArgs<K, V> : EventArgs
    {
        public Type Type
        {
            get;
            set;
        }
    
        public K Key
        {
            get;
            set;
        }
    
        public V Value
        {
            get;
            set;
        }
    }
    
    public class OwnDict<K, V> : IDictionary<K, V>
    {
        public delegate void DictionaryChanged(object sender, DictChangedEventArgs<K, V> e);
    
        public event DictionaryChanged OnDictionaryChanged;
    
        private IDictionary<K, V> innerDict;
    
        public OwnDict()
        {
            innerDict = new Dictionary<K, V>();
        }
    
        public void Add(K key, V value)
        {
            if (OnDictionaryChanged != null)
            {
                OnDictionaryChanged(this, new DictChangedEventArgs<K, V>() { Type = Type.AddItem, Key = key, Value = value });
            }
    
            innerDict.Add(key, value);
        }
    
        // ...
        // ...
    }
