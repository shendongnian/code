    void Main()
    {
      new WorkerBase
      (
       () => Console.WriteLine(ThreadContext.CallerTrace.ToString())
      )
      .Start();
    }
    
    public sealed class WorkerBase
    {
      Action _workerBody;
    
      public WorkerBase(Action workerBody)
      {
        _workerBody = workerBody;
      }
      
      public void Start()
      {
        var capturedStack = new StackTrace(1);
      
        new Thread
            (
              () =>
                {
                  ThreadContext.CallerTrace = capturedStack;
                  
                  _workerBody();
                }
            )
            .Start();
      }
    }
    
    public static class ThreadContext
    {
      [ThreadStatic]
      public static StackTrace CallerTrace;
    }
