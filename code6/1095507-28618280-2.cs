    public static class ExtensionMethods
    {
        public static IEnumerable<T> PartialDistinct<T>(this IEnumerable<T> source, Func<T, bool> filter)
        {
            return PartialDistinct(source, filter, EqualityComparer<T>.Default);
        }
        public static IEnumerable<T> PartialDistinct<T>(this IEnumerable<T> source, Func<T, bool> filter, IEqualityComparer<T> comparer)
        {
            HashSet<T> seen = new HashSet<T>(comparer);
            foreach (var item in source)
            {
                if (filter(item))
                {
                    if (seen.Add(item))
                    {
                        yield return item;
                    }
                }
                else
                {
                    yield return item;
                }
            }
        } 
