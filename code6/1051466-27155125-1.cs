    public class MyCustomComparer : IEqualityComparer<IEnumerable<MyKey>>
    {
        public bool Equals(IEnumerable<MyKey> x, IEnumerable<MyKey> y)
        {
            return x.SequenceEqual(y);
        }
    
        public int GetHashCode(IEnumerable<MyKey> obj)
        {
            return string.Join(",", obj.Select(s => s.Name)).GetHashCode();
        }
    
    }
