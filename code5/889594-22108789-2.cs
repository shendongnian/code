    class FooComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            // Doesn't handle null arguments!
            return x.X == y.X;
        }
        public int GetHashCode(Foo obj)
        {
            return obj.X;
        }
    }
