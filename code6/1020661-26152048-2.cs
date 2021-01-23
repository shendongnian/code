        /// <summary>
        /// Enumerate through all items in the list between first and last, inclusive.  First and last need not be in the list.
        /// </summary>
        public static IEnumerable<KeyValuePair<TKey, TValue>> Between<TKey, TValue>(this SortedList<TKey, TValue> list, TKey first, TKey last)
        {
            if (list == null)
                throw new ArgumentNullException();
            var comparer = list.Comparer;
            var index = list.Keys.BinarySearch(first, comparer);
            if (index < 0) // There can be no duplicated keys in SortedList.
                index = ~index;
            for (int count = list.Count; index < count; index++)
            {
                var key = list.Keys[index];
                if (comparer.Compare(key, last) > 0)
                    break;
                yield return new KeyValuePair<TKey, TValue>(key, list.Values[index]);
            }
        }
        public static SortedList<TKey, double> ComputeGrowth<TKey>(this SortedList<TKey, double> list)
        {
            var count = list.Count;
            SortedList<TKey, double> newList = new SortedList<TKey, double>(count, list.Comparer);
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                    newList.Add(list.Keys[i], 0.0); // Is this what you want?
                else
                    newList.Add(list.Keys[i], (list.Values[i] - list.Values[i - 1]) / list.Values[i - 1]); // Any need to check for division by zero?
            }
            return newList;
        }
