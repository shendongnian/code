    public enum Source
    {
        Observable1,
        Observable2,
    }
    // Type is Source.Observable1
    IObservable<Source> observable1;
    // Type is Source.Observable2
    IObservable<Source> observable2;
    var mergedObservables = observable1.Select(x => Source.Observable1)
        .Merge(observable2.Select(x => Source.Observable2));
    mergedObservables 
        .Scan(
            new
            {
                Value = (Source?)null,
                CurrentUpdateTask = (Task)null
            },
            (tuple, value)
            {
                if ((tuple.CurrentUpdateTask == null) || (tuple.CurrentUpdateTask.IsCompleted))
                {
                    // No update running. Start updating.
                    return new
                    {
                        Value = value,
                        CurrentUpdateTask = Update()  //Some Task-returning method that does the update.
                    };
                }
                // Update in flight. Ignore value.
                return new
                {
                    Value = (Source?)null,
                    tuple.CurrentUpdateTask
                };
            })
        .Where(tuple => tuple.Value.HasValue)
        .Select(tuple.Value.Value)
        .Subscribe(...);
