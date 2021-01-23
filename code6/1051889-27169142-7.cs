    public static class ObservableExtensions
    {
        public static IObservable<T> DelayByOne<T>(
            this IObservable<T> source)
        {
            return source.Scan(
                Tuple.Create(default(T), default(T)),
                    (a, i) => Tuple.Create(i,a.Item1))
                .Select(a => a.Item2).Skip(1);
        }
    }
