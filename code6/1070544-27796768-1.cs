    public static class DictionaryExtensions
    {
        public static void Add<TKey, TValueList, TValue>(this IDictionary<TKey, TValueList> listDictionary, TKey key, TValue value)
            where TValueList : IList<TValue>, new()
        {
            if (listDictionary == null)
                throw new ArgumentNullException();
            TValueList values;
            if (!listDictionary.TryGetValue(key, out values))
                listDictionary[key] = values = new TValueList();
            values.Add(value);
        }
        public static bool TryGetValue<TKey, TValueList, TValue>(this IDictionary<TKey, TValueList> listDictionary, TKey key, int index, out TValue value)
            where TValueList : IList<TValue>
        {
            TValueList list;
            if (!listDictionary.TryGetValue(key, out list))
                return Returns.False(out value);
            if (index < 0 || index >= list.Count)
                return Returns.False(out value);
            value = list[index];
            return true;
        }
        public static bool TryRemoveFirst<TKey, TValueList, TValue>(this IDictionary<TKey, TValueList> listDictionary, TKey key, out TValue value)
            where TValueList : IList<TValue>
        {
            TValueList list;
            if (!listDictionary.TryGetValue(key, out list))
                return Returns.False(out value);
            var count = list.Count;
            if (count > 0)
            {
                value = list[0];
                list.RemoveAt(0);
                if (--count == 0)
                    listDictionary.Remove(key);
                return true;
            }
            else
            {
                listDictionary.Remove(key); // Error?
                return Returns.False(out value);
            }
        }
    }
    public static class Returns
    {
        public static bool False<TValue>(out TValue value)
        {
            value = default(TValue);
            return false;
        }
    }
