    var observable = Observable.Create<int>(async (observer, cancel) =>
    {
        for (var i = 0; !cancel.IsCancellationRequested && i < 100; i++)
        {
            await Task.Yield();
            observer.OnNext(i);  // Instead of yield return.
        }
    });
    
    // Necessary, since the Observable is 100% async.
    var end = Util.KeepRunning();
    
    (from i in observable
     select i * 2).Subscribe(i => Console.WriteLine(i), () => end.Dispose());
