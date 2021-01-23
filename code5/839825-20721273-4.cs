    public IObservable<Unit> ScheduleWork(IObservable<Unit> cancelSignal)
    {
        // Performs work on an interval
        // stops the timer (but finishes any work in progress) when the cancelSignal is received
        var workTimer = Observable
            .Timer(TimeSpan.Zero, TimeSpan.FromSeconds(10))
            .TakeUntil(cancelSignal)
            .Select(_ =>
            {
                DoWork();
                return Unit.Default;
            })
            .IgnoreElements();
        // starts a timer after cancellation that will eventually throw a timeout exception.
        var timeoutAfterCancelSignal = cancelSignal
            .SelectMany(c => Observable.Never<Unit>().Timeout(TimeSpan.FromSeconds(5)));
        // Use Amb to listen to both the workTimer
        // and the timeoutAfterCancelSignal
        // Since neither produce any data we are really just
        // listening to see which will complete first.
        // if the workTimer completes before the timeout
        // then Amb will complete without error.
        // However if the timeout expires first, then Amb
        // will produce an error
        return Observable.Amb(workTimer, timeoutAfterCancelSignal);
    }
    // Usage
    var cts = new CancellationTokenSource();
    var s = ScheduleWork(cts.Token.AsObservable());
    using (var finishedSignal = new ManualResetSlim())
    {
        s.Finally(finishedSignal.Set).Subscribe(
            _ => { /* will never be called */},
            error => { /* handle error */ },
            () => { /* canceled without error */ } );
        Console.ReadKey();
        cts.Cancel();
        finishedSignal.Wait();
    }
