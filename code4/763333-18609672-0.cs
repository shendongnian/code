    public static class IEnumerableExt
    {
        public static IEnumerable<int> FindIndices<T>(this IEnumerable<T> self, Predicate<T> predicate)
        {
            int i = 0;
            foreach (var element in self)
            {
                if (predicate(element))
                    yield return i;
                ++i;
            }
        }
    }
