    public static class ObservableExtensions
    {
        public static IObservable<T> ObserveSafe<T>(this IObservable<T> observable, Action<Exception> onError)
        {
            var subject = new Subject<T>();
            
            observable.Subscribe(x =>
                                 {
                                     try
                                     {
                                         subject.OnNext(x);
                                     }
                                     catch (Exception exception)
                                     {
                                         onError(exception);
                                     }
                                 },
                                 exception =>
                                 {
                                     try
                                     {
                                         subject.OnError(exception);
                                     }
                                     catch (Exception ex)
                                     {
                                         onError(ex);
                                     }
                                     finally
                                     {
                                         subject.Dispose();
                                     }
                                 },
                                 () =>
                                 {
                                     try
                                     {
                                         subject.OnCompleted();
                                     }
                                     catch (Exception ex)
                                     {
                                         onError(ex);
                                     }
                                     finally
                                     {
                                         subject.Dispose();
                                     }
                                 });
            return subject;
        }
    }
