    var statusSignal = statusProvider
                .Subscribe(statusKey)  //returns an IObservable<string>
                .Select(st => st.ToUpper())
                .DistinctUntilChanged()
                .Publish()
                .RefCount();
    // An observable that produces "bad" after a delay and then "hangs indefinately" after that
    var badTimer = Observable
        .Return("bad")
        .Delay(TimeSpan.FromSeconds(30))
        .Concat(Observable.Never<string>());
    // A repeating badTimer that resets the timer whenever a good signal arrives.
    // The "indefinite hang" in badTimer prevents this from restarting the timer as soon
    // as it produces a "bad".  Which prevents you from getting a string of "bad" messages
    if the statusProvider is silent for many minutes.
    var badSignal = badTimer.TakeUntil(statusSignal).Repeat();
    // listen to both good and bad signals.
    return Observable
        .Merge(statusSignal, badSignal)
        .Replay(1)
        .RefCount();
