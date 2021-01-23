    public class MultiFieldComparer : IEqualityComparer<IEnumerable<object>>
    {
        public bool Equals(IEnumerable<object> x, IEnumerable<object> y)
        {
            if(x == null || y == null) return false;
            return x.SequenceEqual(y);
        }
        public int GetHashCode(IEnumerable<object> objects)
        {
            if(objects == null) return 0;
            unchecked  
            {
                int hash = 17;
                foreach(object obj in objects)
                    hash = hash * 23 + (obj == null ? 0 : obj.GetHashCode());
                return hash;
            }
        }
    }
