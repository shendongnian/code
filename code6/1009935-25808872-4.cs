    public static class EnumerableExtensions
    {
        public static IEnumerable<T> TrimEnd<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            var accumulator = new LinkedList<T>();
            foreach (var item in enumerable)
            {
                if (predicate(item))
                {
                    accumulator.AddLast(item);
                }
                else
                {
                    foreach (var accumulated in accumulator)
                    {
                        yield return accumulated;
                    }
                    accumulator.Clear();
                    yield return item;
                }
            }
        }
    }
