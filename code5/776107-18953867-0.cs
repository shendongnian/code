    public static class DynamicEnumerable
    {
        public static IEnumerable<T> DynamicCast<T>(this IEnumerable source)
        {
            foreach (dynamic current in source)
            {
                yield return (T)(current);
            }
        }
    }
