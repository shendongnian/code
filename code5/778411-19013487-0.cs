    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Zip<T, TResult>(
            this IEnumerable<T> first,
            IEnumerable<T> second,
            Func<T, T, TResult> resultSelector
        )
        {
            using(var firstEnumerator = first.GetEnumerator())
            using(var secondEnumerator = second.GetEnumerator())
            {
                while(firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
                {
                    yield return resultSelector(firstEnumerator.Current,
                                                secondEnumerator.Current);
                }
            }
        }
    }
