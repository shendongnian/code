    public static class ObservableExtensions
    {
        public static IObservable<TResult> Cast<TResult>(
            this IObservable<object> source)
        {
            return Observable.Create<TResult>(o =>
                source.Subscribe(x => {
                    try
                    {
                        var cast = (TResult)x;
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
