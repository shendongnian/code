    AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionFunction;
    
    private void UnhandledExceptionFunction(Object sender, UnhandledExceptionEventArgs args)
    {
    Exception ex = (Exception)args.ExceptionObject)
    StackFrame frame = new StackFrame(0);
    string method;
    method = frame.GetMethod().ReflectedType.FullName;
    
    }
