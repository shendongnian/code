    class IEnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> a, IEnumerable<T> b)
        {
            return Enumerable.SequenceEqual(a, b);
        }
    
        public int GetHashCode(IEnumerable<T> source)
        {
            //Some hashing algorithm for the source
        }
    }
