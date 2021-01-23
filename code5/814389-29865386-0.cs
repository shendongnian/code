    public static class ObservableExtensions
    {
        public static IObservable<T[]> Batch<T>(this IObservable<T> observable, TimeSpan timespan)
        {
            return observable.GroupByUntil(x => 1, g => Observable.Timer(timespan))
                             .Select(x => x.ToArray())
                             .Switch();
        }
    }
