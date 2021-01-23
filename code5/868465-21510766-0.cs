    public static class DbExtensions
    {
        public static IEnumerable<T> ManyOrNull<T>(this IEnumerable<T> elements)
        {
            return elements.Any() ? elements: null;
        }
    }
