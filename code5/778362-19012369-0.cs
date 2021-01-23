    public class FooComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            if (x == null ^ y == null)
                return false;
            if (x == null && y == null)
                return true;
            return x.Bar == y.Bar;
        }
        public int GetHashCode(Foo obj)
        {
            if (obj == null)
                return 0;
            return obj.Bar.GetHashCode();
        }
    }
