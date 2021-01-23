    Dispatcher.CurrentDispatcher.UnhandledException += OnDispatcherUnhandledException;
    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        Assert.Fail("Exception: {0}", e.Exception);
    }
