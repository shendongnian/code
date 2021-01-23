    interface DictionaryReturn<T> {
        T Value {get;}
        bool Success {get;}
    }
    ...
    class Dictionary<K,V> {
        ...
        public DictionaryReturn<V> TryGetValue(K key) {
            ...
        }
    }
