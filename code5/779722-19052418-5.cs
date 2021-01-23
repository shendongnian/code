    public static class SpliceExtension
    {
        public static IEnumerable<T> Splice<T>(this IEnumerable<T> list, int offset, int count)
        {
            return list.Skip(offset).Take(count);
        }
    }
