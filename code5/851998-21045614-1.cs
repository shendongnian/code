    public static partial class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> source, int length)
        {
            if (length == 0)
            {
                yield return Enumerable.Empty<T>();
                yield break;
            }
            int index = 0;
            foreach (T item in source)
            {
                IEnumerable<T> remainder = source.ExceptAt(index);
                IEnumerable<IEnumerable<T>> tails = GetPermutations(remainder, length - 1);
                foreach (IEnumerable<T> tail in tails)
                    yield return tail.Prepend(item);
                index++;
            }
        }
        public static IEnumerable<T> ExceptAt<T>(this IEnumerable<T> source, int index)
        {
            return source.Take(index).Concat(source.Skip(index + 1));
        }
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T first)
        {
            yield return first;
            foreach (T item in source)
                yield return item;
        }
    }
