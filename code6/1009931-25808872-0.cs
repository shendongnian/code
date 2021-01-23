    public static class EnumerableExtensions
    {
        public static IEnumerable<T> TrimEnd<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            var accumulator = new Queue<T>();
            foreach (var item in enumerable)
            {
                if (predicate(item))
                {
                    accumulator.Enqueue(item);
                }
                else
                {
                    while (accumulator.Count > 0)
                    {
                        yield return accumulator.Dequeue();
                    }
                    yield return item;
                }
            }
        }
    }
