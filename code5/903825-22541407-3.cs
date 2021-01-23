    class IEnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> a, IEnumerable<T> b)
        {
            return Enumerable.SequenceEqual(a, b);
        }
    
        public int GetHashCode(IEnumerable<T> source)
        {
            if (source == null)
            {
                return 0;
            }
            int shift = 0;
            int result = 1;
            foreach (var item in source)
            {
                int hash = item != null ? item.GetHashCode() : 17;
                result ^= (hash << shift)
                        | (hash >> (32 - shift))
                        & (1 << shift - 1);
                shift = (shift + 1) % 32;
            }
            return result;
        }
    }
