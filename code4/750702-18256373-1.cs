    public class SequenceComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(IEnumerable<T> obj)
        {
            return obj.Take(5).Aggregate(37, 
                (acc, item) => acc * 79 + item.GetHashCode());
        }
    }
