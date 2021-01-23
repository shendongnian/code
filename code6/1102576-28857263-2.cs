    public class PredicateComparer<T> : IComparer<T>
    {
        private readonly Func<T, bool>[] ordinals;
        public PredicateComparer(IEnumerable<Func<T, bool>> predicates)
        {
            ordinals = predicates.ToArray();
        }
        public int Compare(T x, T y)
        {
            return GetOrdinal(x) - GetOrdinal(y);
        }
        private int GetOrdinal(T item)
        {
            for (int i = 0; i < ordinals.Length; i++)
                if (ordinals[i](item))
                    return i - ordinals.Length;
            return 0;
        }
    }
