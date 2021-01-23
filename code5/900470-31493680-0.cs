    System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
    
    // Catch all handled exceptions in managed code, before the runtime searches the Call Stack 
    AppDomain.CurrentDomain.FirstChanceException += FirstChanceException;
    
    // Catch all unhandled exceptions in all threads.
    AppDomain.CurrentDomain.UnhandledException += UnhandledException;
    
    // Catch all unobserved task exceptions.
    TaskScheduler.UnobservedTaskException += UnobservedTaskException;
    
    // Catch all unhandled exceptions.
    System.Windows.Forms.Application.ThreadException += ThreadException;
    
    // Catch all WPF unhandled exceptions.
    Dispatcher.CurrentDispatcher.UnhandledException += DispatcherUnhandledException;
