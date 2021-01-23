    public class Class : IDisposable
    {
      private Task task;
      private CancellationTokenSource cts = new CancellationTokenSource();
    
      Class()
      {
        task = new Task(Run, cts.Token, TaskCreationOptions.LongRunning);
        task.Start();
      }
    
      public void Dispose()
      {
        cts.Cancel();
      }
    
      private void Run()
      {
        while (!cts.Token.IsCancellationRequested)
        {
          // Your stuff goes here.
        }
      }
    }
