    public static class Filters
    {
        public static IQueryable<FooTable> WithPrefix(this IQueryable<FooTable> item, string prefix)
        {
            return item.Where(i => i.Foo.StartsWith(prefix));
            // note that this should be the same code you have in the 
            // Prefix() method inside HelperFoo...
        }
    }
