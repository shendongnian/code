    public ActionResult Test()
    {
        // Start the async work, and attach a continuation which happens if exceptions occur
        Task.Run(() => doWork())
        .ContinueWith(t =>
        {
           var ex = t.Exception.InnerException;
           LogException(ex);
        }, TaskContinuationOptions.OnlyOnFaulted);
        return View();
    }
