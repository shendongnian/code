    AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionFunction;
    
    private void UnhandledExceptionFunction(Object sender, UnhandledExceptionEventArgs args)
    {
        Exception ex = (Exception)(args.ExceptionObject);
        System.Diagnostics.StackFrame frame = new System.Diagnostics.StackFrame(0);
        string method;
        method = frame.GetMethod().ReflectedType.FullName;
    }
