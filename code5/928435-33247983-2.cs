    // Create a disposable that keeps the query running.
    // This is necessary, since the observable is 100% async.
    var end = Util.KeepRunning();
    
    observable.Subscribe(
        c => Console.WriteLine(c.ToString()),
        () => end.Dispose());
