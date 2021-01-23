    public static class Extensions
    {
        public IEnumerable<MyType> Filter(this IEnumerable<MyType> e, string filter)
        {
            return e.Where(T => T.Filter.Equals(filter));
        }
    }
