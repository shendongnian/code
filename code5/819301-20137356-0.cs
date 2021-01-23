    public static class Extension
        {
            public static SortedList<TValue, TKey> ShiftKeyValuePair<TKey, TValue>(this SortedList<TKey, TValue> instance)
            {
                SortedList<TValue, TKey> key = new SortedList<TValue, TKey>();
                foreach (var item in instance)
                    key.Add(item.Value, item.Key);
                return key;
            }
        }
