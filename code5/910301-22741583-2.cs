    // Instantiate this once, we'll use it in a closure multiple times.
    var delay = Observable.Empty<int>().Delay(TimeSpan.FromMilliseconds(10));
    // start with a source of individual items to be worked.
    Observable.Range(0, 100000)
        // Create batches of work.
        .Buffer(20)
        // Select an observable for the batch of work, and concat a delay.
        .Select(batch => batch.ToObservable().Concat(delay))
        // Concat those together and form a "process, delay, repeat" observable.
        .Concat()
        // Subscribe!
        .Subscribe(Console.WriteLine);
    
    // Make sure we wait for our work to be one.
    // There are other ways to sync up, like async / await.
    Console.ReadLine();
