    var wasUnobservedException = false;
    TaskScheduler.UnobservedTaskException += (s, args) => wasUnobservedException = true;
    var res = Task.Run(() =>
    {
        throw new NotImplementedException();
        return new DateTime?();
    });
    ((IAsyncResult)res).AsyncWaitHandle.WaitOne(); // Wait for the task to complete
    res = null; // Allow the task to be GC'ed
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Assert.IsTrue(wasUnobservedException);
