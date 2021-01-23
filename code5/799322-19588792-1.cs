    public class ListComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals(List<T> x, List<T> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<T> obj)
        {
            int hash = 19;
            foreach (var o in obj)
            {
                hash = hash * 31 + o.GetHashCode();
            }
            return hash;
        }
    }
