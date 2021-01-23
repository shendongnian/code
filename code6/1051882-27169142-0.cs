    public static class ObservableExtensions
    {
        public static IObservable<T> DelayByOne<T>(this IObservable<T> source)
        {
            return source.Scan(
                Tuple.Create(default(T), default(T)), (a, i) => Tuple.Create(a.Item2,i))
                .Select(a => a.Item1).Skip(1); 
        }
    }
