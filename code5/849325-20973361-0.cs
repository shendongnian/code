    var timeout = TimeSpan.FromMilliseconds(10000);
    T item;
    while (_blockingCollection.TryTake(out item, timeout))
    {
         // do something with item
    }
    // If we end here. Either we have a timeout or we are out of items.
    if (!_blockingCollection.IsAddingCompleted)
       throw MyTimeoutException();
