    private void OnDispatcherUnhandledException(object sender, 
    System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        string stackTrace = e.Exception.StackTrace;
    }
