    Task.Factory.StartNew(() =>
    {
         return GetStuff():                  
    }).ContinueWith(t =>
    {
        // InvokeOnMainThread(t.Result); // Note that this doesn't need to "Invoke" now
        UseStuff(t.Result); 
    }, TaskScheduler.FromCurrentSynchronizationContext()); // Moves to main thread
