    foreach (var item in BlockingCollection.
        GetConsumingEnumerable(CancellationToken))
    {
        //consume item
    }
    if (CancellationToken.IsCancellationRequested)
        foreach (var item in BlockingCollection)
        {
            //log item
        }
