            public static class Returns
            {
                public static bool False<TValue>(out TValue value)
                {
                    value = default(TValue);
                    return false;
                }
            }
            public static class ListDictionaryExtensions
            {
                public static void Add<TKey, TValue>(this IDictionary<TKey, List<TValue>> listDictionary, TKey key, TValue value)
                {
                    if (listDictionary == null)
                        throw new ArgumentNullException();
                    List<TValue> values;
                    if (!listDictionary.TryGetValue(key, out values))
                    {
                        listDictionary[key] = (values = new List<TValue>());
                    }
                    values.Add(value);
                }
                public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, List<TValue>> listDictionary, TKey key, int index, out TValue value)
                {
                    List<TValue> list;
                    if (!listDictionary.TryGetValue(key, out list))
                        return Returns.False(out value);
                    if (index < 0 || index >= list.Count)
                        return Returns.False(out value);
                    value = list[index];
                    return true;
                }
                public static void SortAll<TKey, TValue>(this IDictionary<TKey, List<TValue>> listDictionary)
                {
                    if (listDictionary == null)
                        return;
                    foreach (var list in listDictionary.Values)
                        list.Sort();
                }
                public static int MaxCount<TKey, TValue>(this IDictionary<TKey, List<TValue>> listDictionary)
                {
                    if (listDictionary == null)
                        return 0;
                    int count = 0;
                    foreach (var list in listDictionary.Values)
                        count = Math.Max(count, list.Count);
                    return count;
                }
            }
