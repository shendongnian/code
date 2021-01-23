    IObservable<T> requests = ...;
    requests.GroupBy(request => PickExternalSystem(request))
        .Select(group => group // group.Key is the TExternalSystem
            .Select(request => Observable.Defer(() => group.Key.ExecuteAsync(request)))
            .Merge(maxConcurrency: group.Key.MaxConcurrency))
        .Merge() // merge the results of each group back together again
        .Subscribe(result => ...);
