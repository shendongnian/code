    public class MyInsertionOrderDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private List<TKey> keysList;
        private Dictionary<TKey, TValue> dict;
        
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (TKey key in keysList)
            {
                TValue value = dict[key];
                yield return new KeyValuePair<TKey, TValue>(key, value);
            }
        }
        
        // TODO implement interface
        // when adding:
        // keysList.Add(key);
        // dict.Add(key, value);
        
        // when removing:
        // keysList.Remove(key);
        // dict.Remove(key);
        // you could also implement an indexer property like
        public KeyValuePair<TKey, TValue> this[int index] { get { ... } }
    }
