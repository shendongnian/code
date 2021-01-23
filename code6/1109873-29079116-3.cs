    public class MyObjectEqualityComparer : IEqualityComparer<MyObject>
    {
        public static readonly MyObjectEqualityComparer Default = new MyObjectEqualityComparer();
        protected MyObjectEqualityComparer()
        {
        }
        public bool Equals(MyObject x, MyObject y)
        {
            if (object.ReferenceEquals(x, null))
            {
                return object.ReferenceEquals(y, null);
            }
            if (object.ReferenceEquals(y, null))
            {
                return false;
            }
            // Here we know that x != null && y != null;
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            return x.Id == y.Id && x.Name == y.Name;
        }
        public int GetHashCode(MyObject obj)
        {
            if (obj == null)
            {
                return 0;
            }
            unchecked
            {
                // From http://stackoverflow.com/a/263416/613130
                int hash = 17;
                hash = hash * 23 + obj.Id.GetHashCode();
                hash = hash * 23 + (obj.Name != null ? obj.Name.GetHashCode() : 0);
                return hash;
            }
        }
    }
