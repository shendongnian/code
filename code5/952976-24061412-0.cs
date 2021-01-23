    public static class ExtensionMethods
    {
        public static bool AreAll<T>(this T[] source, Func<T, bool> condition)
        { return source.Where(condition).Count() == source.Count(); }
    }
