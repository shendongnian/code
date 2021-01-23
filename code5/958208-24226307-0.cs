    // define possible orderings
    public enum SortOrder
    {
        Ascending,
        Descending,
        Constant,
        Unordered,
        Empty
    }
    public static class Extensions
    {
        // simple method to get the ordering of an enumeration
        public static SortOrder GetOrdering<T>(this IEnumerable<T> list, 
            IComparer<T> comparer = null) where T : IComparable<T>
        {
            if (!list.Any())
                return SortOrder.Empty;
            if (comparer == null)
                comparer = Comparer<T>.Default;
            SortOrder ret = SortOrder.Constant;
            T last = list.First();
            foreach (T v in list.Skip(1).Select(a=>a))
            {
                var c = comparer.Compare(last, v);
                last = v;
                if (c == 0) continue;
                if ((c < 0 && ret == SortOrder.Ascending)
                    || c > 0 && ret == SortOrder.Descending)
                    return SortOrder.Unordered;
                else if (ret == SortOrder.Constant)
                    ret = c < 0 ? SortOrder.Descending : SortOrder.Ascending;
            }
            return ret;
        }
    }
