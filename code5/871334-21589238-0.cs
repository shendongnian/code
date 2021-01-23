    public static IObservable<T> Pace(this IObservable<T> source, TimeSpan interval)
    {
        return source.Select(i => Observable.Empty<T>()
                                            .Delay(interval)
                                            .StartWith(i)).Concat();
    }
