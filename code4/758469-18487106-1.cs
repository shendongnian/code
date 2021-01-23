    static IObservable<int> SomeRxWork()
    {
        return Observable.Create<int>(async (o, token) =>
        {
            try
            {
                o.OnNext(await SomeAsyncWork(token));
                o.OnCompleted();
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                o.OnError(ex);
            }
        });
    }
