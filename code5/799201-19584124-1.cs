    class MyFooComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            return x.Id == y.Id && x.someKey != y.someKey;
        }
        public int GetHashCode(Foo obj)
        {
            return obj.Id.GetHashCode();
        }
    }
