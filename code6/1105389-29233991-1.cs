    public static class ObservableEx
    {
        public static IConnectableObservable<TItem> ReplayWithReset<TItem, TReset>(this IObservable<TItem> src, IObservable<TReset> resetTrigger)
        {
            return new ClearableReplaySubject<TItem, TReset>(src, resetTrigger);
        }
    }
