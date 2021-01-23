    public static class EnumerableExt
    {
        public static List<T?> ToNullableList<T>(this IEnumerable<T> sequence) where T: struct
        {
            return sequence.Cast<T?>().ToList();
        }
    }
