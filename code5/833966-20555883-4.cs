    public delegate void TaskResultEventHandler<T>(object sender, TaskResultEventArgs<T> e);
    
    public sealed class TaskResultEventArgs<T> : EventArgs
    {
          public T Result { get; private set; }
          public Exception Error { get; private set; }
          public bool WasCancelled { get; private set; }
        
          public TaskResultEventArgs(T result, Exception error, bool wasCancelled)
          {
            this.Result = result;
            this.Error = error;
            this.WasCancelled = wasCancelled;
          }
    }
