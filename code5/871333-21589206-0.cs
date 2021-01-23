    var interval = Observable.Timer(TimeSpan.FromMilliseconds(500)).IgnoreElements();
    var observable2 = observable
        .Select(e => Observable.Return(e).Concat(interval))
        .Concat();
    observable2.Subscribe(e =>
        {
            // will have a minimum interval of 500ms between calls
        });
