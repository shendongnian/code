    /// <summary>
    /// Used for handling WPF exceptions bound to the UI thread.
    /// Handles the <see cref="System.Windows.Threading.DispatcherUnhandledExceptionEventHandler"/> events.
    /// </summary>
    [HandleProcessCorruptedStateExceptions]
    private static DispatcherUnhandledExceptionEventHandler DispatcherUnhandledException
    {
        // catch error ...            
    }
    
    /// <summary>
    /// Used for handling WinForms exceptions bound to the UI thread.
    /// Handles the <see cref="System.Threading.ThreadExceptionEventHandler"/> events in <see cref="System.Windows.Forms.Application"/> namespace.
    /// </summary>
    [HandleProcessCorruptedStateExceptions]
    private static ThreadExceptionEventHandler ThreadException
    {
        // catch error ...        
    }
    
    /// <summary>
    /// Used for handling general exceptions bound to the main thread.
    /// Handles the <see cref="AppDomain.UnhandledException"/> events in <see cref="System"/> namespace.
    /// </summary>
    [HandleProcessCorruptedStateExceptions]
    private static UnhandledExceptionEventHandler UnhandledException
    {
        // catch error ...        
    }
    
    /// <summary>
    /// Used for handling System.Threading.Tasks bound to a background worker thread.
    /// Handles the <see cref="UnobservedTaskException"/> event in <see cref="System.Threading.Tasks"/> namespace.
    /// </summary>
    [HandleProcessCorruptedStateExceptions]
    private static EventHandler<UnobservedTaskExceptionEventArgs> UnobservedTaskException
    {
        // catch error ...        
    }
    
    /// <summary>
    /// This is new to .Net 4 and is extremely useful for ensuring that you ALWAYS log SOMETHING.
    /// Whenever any kind of exception is fired in your application, a FirstChangeExcetpion is raised,
    /// even if the exception was within a Try/Catch block and safely handled.
    /// This is GREAT for logging every wart and boil, but can often result in too much spam, 
    /// if your application has a lot of expected/handled exceptions.
    /// </summary>
    [HandleProcessCorruptedStateExceptions]
    private static EventHandler<FirstChanceExceptionEventArgs> FirstChanceException
    {
       // catch error ...        
    }
