    public static class ExtensionMethods
    {
        public static bool AreAll<T>(this T[] source, Func<T, bool> condition)
        { return source.Where(condition).Count() == source.Count(); }
        public static bool AreAllTheSame<T>(this IEnumerable<T> source)
        { return source.Distinct().Count() == 1; }
    }
