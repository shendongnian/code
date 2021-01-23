    public class SequenceEqualityComparer : IEqualityComparer<IEnumerable<int>>
    {
        public bool Equals(IEnumerable<int> x, IEnumerable<int> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(IEnumerable<int> obj)
        {
            return obj.GetHashCode();
        }
    }
