    public static class ObservableExtensions
    {
        public static IObservable<TResult> Cast<TSource, TResult>(
            this IObservable<TSource> source)
        {
            return Observable.Create<TResult>(o =>
                source.Subscribe(x => {
                    try
                    {
                        var cast = (TResult)(object)x;
                        o.OnNext(cast);
                    }
                    catch (InvalidCastException ex)
                    {
                        o.OnError(ex);
                    }
                },
                o.OnError,
                o.OnCompleted));
        }
    }
