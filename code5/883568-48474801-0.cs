    public static class IEnumerableExt
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> source)
        {
            if (source.Count() > 0)
                return source.ElementAt(0);
            return default(T);
        }
    }
