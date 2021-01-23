    public static class CoSorter
    {
        public static void Sort<TKey, TValue>(this TKey[] keys, TValue[] values, int start, int count)
        {
            QuickCosort(keys, values, start, count - 1, Comparer<TKey>.Default);
        }
        public static void Sort<TKey, TValue>(this TKey[] keys, TValue[] values, int start, int count, IComparer<TKey> comparer)
        {
            QuickCosort(keys, values, start, count - 1, comparer);
        }
        private static void QuickCosort<TKey, TValue>(TKey[] keys, TValue[] values, int left, int right, IComparer<TKey> comparer)
        {
            int i = left, j = right;
            var pivot = keys[(left + right) / 2];
            while (i <= j)
            {
                while (comparer.Compare(keys[i], pivot) < 0)
                {
                    i++;
                }
                while (comparer.Compare(keys[j], pivot) > 0)
                {
                    j--;
                }
                if (i <= j)
                {
                    // Swap
                    var tmpKey = keys[i];
                    var tmpVal = values[i];
                    keys[i] = keys[j];
                    values[i] = values[j];
                    keys[j] = tmpKey;
                    values[j] = tmpVal;
                    i++;
                    j--;
                }
            }
            // Recursive calls
            if (left < j)
            {
                QuickCosort(keys, values, left, j, comparer);
            }
            if (i < right)
            {
                QuickCosort(keys, values, i, right, comparer);
            }
        }
    }
