    public class YourService : ServiceBase
    {
      private CancellationTokenSource cts = new CancellationTokenSource();
      private Task mainTask = null;
    
      protected override void OnStart(string[] args)
      {
        mainTask = new Task(Poll, cts.Token, TaskCreationOptions.LongRunning);
        mainTask.Start();
      }
    
      protected override void OnStop()
      {
        cts.Cancel();
        mainTask.Wait();
      }
    
      private void Poll()
      {
        CancellationToken cancellation = cts.Token;
        while (!cancellation.WaitHandle.WaitOne(YourInterval))
        {
          // Put your code to poll here.
          // Occasionally check the cancellation state.
          if (cancellation.IsCancellationRequested)
          {
            break;
          }
        }
      }
    
    }
