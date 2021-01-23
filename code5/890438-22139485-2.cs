    public static class Extensions
    {
        public static IEnumerable<TThis> TakeGreaterThan<TThis>(this IEnumerable<TThis> source, Func<TThis, double> valueFunc, double compareTo)
        {
            double sum = 0.0;
            IEnumerable<TThis> orderedSource = source.OrderByDescending(valueFunc);
            var enumerator = orderedSource.GetEnumerator();
            while (sum <= compareTo && enumerator.MoveNext())
            {
                yield return enumerator.Current;
                sum += valueFunc(enumerator.Current);
            }
        }
    }
