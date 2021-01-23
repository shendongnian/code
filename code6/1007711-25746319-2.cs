    var stateSubject = new Subject<State>();
    
    var state = stateSubject.DistinctUntilChanged().Publish().RefCount();
    
    var disconnectTimer = state        
        .Select(x => x == State.Disconnected
            ? Observable.Timer(TimeSpan.FromSeconds(30))
                .Select(_ => State.DisconnectedRetryTimeout)
            : Observable.Never<State>())
        .Switch();
    
    var statusObservable =
        state.Merge(disconnectTimer);
