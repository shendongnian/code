    /// <summary>
    /// Given a way to determine a collection of elements (for example
    /// children of a parent) and a comparable property of those items
    /// (for example age of a child) this orders a collection of elements
    /// according to the sorting order of the property of the first element
    /// of their respective collections. In case of a tie, fall back to
    /// subsequent elements as appropriate.
    /// </summary>
    public static IOrderedEnumerable<T> OrderBy<T, TKey, TValue>(this IEnumerable<T> @this, Func<T, IEnumerable<TKey>> getKeys, Func<TKey, TValue> getValue)
        where TValue : IComparable<TValue>
    {
        return @this.OrderBy(x => x, new KeyComparer<T, TKey, TValue>(getKeys, getValue));
    }
    private class KeyComparer<T, TKey, TValue> : IComparer<T>
        where TValue : IComparable<TValue>
    {
        private Func<T, IEnumerable<TKey>> GetKeys;
        private Func<TKey, TValue> GetValue;
        public KeyComparer(Func<T, IEnumerable<TKey>> getKeys, Func<TKey, TValue> getValue)
        {
            this.GetKeys = getKeys;
            this.GetValue = getValue;
        }
        public int Compare(T x, T y)
        {
            var xKeys = GetKeys(x).OrderBy(GetValue).Select(GetValue);
            var yKeys = GetKeys(y).OrderBy(GetValue).Select(GetValue);
            foreach (var pair in xKeys.Zip(yKeys, Tuple.Create))
            {
                if (pair.Item1.CompareTo(pair.Item2) != 0)
                    return pair.Item1.CompareTo(pair.Item2);
            }
            return xKeys.Count().CompareTo(yKeys.Count());
        }
    }
