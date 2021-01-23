    public static class IEnumerableExt
    {
        public static T[] ToArrayOrNull<T>(this IEnumerable<T> seq)
        {
            var result = seq.ToArray();
            if (result.Length == 0)
                return null;
            return result;
        }
    }
