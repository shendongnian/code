    IObservable<Gizmo> observable = Observable.FromAsync(
        cancellationToken => GetGizmoAsync(7, cancellationToken));
    // Starts the task:
    IDisposable subscription = observable.Subscribe(...);
    
    // Cancels the task if it is still running:
    subscription.Dispose();
