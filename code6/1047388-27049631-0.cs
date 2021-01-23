    // Type is Source.Observable2
    IObservable<Source> observable2;
    int isActive = 0;
    var mergedObservables = Observable.Merge(
        observable1
            .Where(t => Interlocked.CompareExchange(ref isActive, 1, 2) == 0)
            .Select(x => Source.Observable1),
        observable2
            .Where(t => Interlocked.CompareExchange(ref isActive, 1, 2) == 0)
            .Select(x => Source.Observable2));
    mergedObservables.Subscribe(x =>
    {
        switch (x.Source)
        {
            case Source.Observable1:
            {
                Interlocked.Exchange(ref isActive, 1);
                // Here is some code which causes that observable2 will get some new values. 
                // (this coud be also on an other thread)
                // If this is the case, the new value(s) should be ignored.
                Interlocked.Exchange(ref isActive, 0);
            }
            break;
            case Source.Observable2:
            {
                Interlocked.Exchange(ref isActive, 1);
                // Here is some code which causes that observable1 will get some new values. 
                // (this coud be also on an other thread)
                // If this is the case, the new value(s) should be ignored.
                Interlocked.Exchange(ref isActive, 0);
            }
            break;
        }
    });
