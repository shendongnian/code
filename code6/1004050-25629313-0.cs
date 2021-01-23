    var blockingCollection = ...
    foreach (var obj in blockingCollection.GetConsumingEnumerable(cancellationToken))
    {
        // process the obj
    }
