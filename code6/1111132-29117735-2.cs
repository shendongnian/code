    void Main()
    {
      ThreadHelper.Start(() => Console.WriteLine(ThreadContext.CallerTrace.ToString()));
    }
    
    public static class ThreadHelper
    {
      public static void Start(Action action)
      {
        var capturedStack = new StackTrace(1);
      
        new Thread(() => { ThreadContext.CallerTrace = capturedStack; action(); })
            .Start();
      }
    }
    
    public static class ThreadContext
    {
      [ThreadStatic]
      public static StackTrace CallerTrace;
    }
