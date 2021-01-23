    return LoadNextItem().ContinueWith(t => {
        if (t.Exception != null) {
            throw t.Exception.InnerException;
        }
        string result = t.Result;
        if (result.Contains("target")) {
            Counter.Value = result.Length;
        }
    },
    TaskScheduler.FromCurrentSynchronizationContext());
