    public static class ObservableExtensions
    {
        public static IObservable<TResult> Cast<TResult>(
            this IObservable<object> source)
        {
            return Observable.Create<TResult>(o =>
                source.Subscribe(x => {
                    TResult cast;
                    try
                    {
                        cast = (TResult)x;
                    }
                    catch (InvalidCastException ex)
                    {
                        o.OnError(ex);
                        return;
                    }
                    o.OnNext(cast);
                },
                o.OnError,
                o.OnCompleted));
        }       
    }
