    public static class GenericListExtensions
    {
        public static string ToString<T>(this IList<T> list)
        {
            return string.Join(",", list);
        }
    }
