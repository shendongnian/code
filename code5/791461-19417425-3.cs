    public static class Ext
    {
        public static IConnectableObservable<T> Multicast<T>(this IObservable<T> obs, Func<ISubject<T>> subjectFactory)
        {
            return new ReconnectableObservable<T, T>(obs, subjectFactory);
        }
        public static IConnectableObservable<T> ReplayReconnect<T>(this IObservable<T> obs, int replayCount)
        {
            return obs.Multicast(() => new ReplaySubject<T>(replayCount));
        }
        public static IConnectableObservable<T> PublishReconnect<T>(this IObservable<T> obs)
        {
            return obs.Multicast(() => new Subject<T>());
        }
    }
