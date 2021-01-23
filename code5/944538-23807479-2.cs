    public static class SortedListExtensions
    {
        public static int BinarySearch<TKey, TValue>(this SortedList<TKey, TValue> sortedList, TKey keyToFind, IComparer<TKey> comparer = null)
        {
            // need to create an array because SortedList.keys is a private array
            var keys = sortedList.Keys;
            TKey[] keyArray = new TKey[keys.Count];
            for (int i = 0; i < keyArray.Length; i++)
                keyArray[i] = keys[i];
            if(comparer == null) comparer = Comparer<TKey>.Default;
            int index = Array.BinarySearch<TKey>(keyArray, keyToFind, comparer);
            return index;
        }
        public static IEnumerable<TKey> GetKeyRangeBetween<TKey, TValue>(this SortedList<TKey, TValue> sortedList, TKey low, TKey high, IComparer<TKey> comparer = null)
        {
            int lowIndex = sortedList.BinarySearch(low, comparer);
            if (lowIndex < 0)
            {
                // list doesn't contain the key, find nearest behind
                // If not found, BinarySearch returns the complement of the index
                lowIndex = ~lowIndex;
            }
            int highIndex = sortedList.BinarySearch(high, comparer);
            if (highIndex < 0)
            {
                // list doesn't contain the key, find nearest before
                // If not found, BinarySearch returns the complement of the index
                highIndex = ~highIndex - 1;
            }
            var keys = sortedList.Keys;
            for (int i = lowIndex; i < highIndex; i++)
            {
                yield return keys[i];
            }
        }
    }
