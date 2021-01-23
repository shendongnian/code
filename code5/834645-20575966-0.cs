    public static class Extensions
    {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> self)
        {
            return self == null ? Enumerable.Empty<T>() : self;
        }
    }
