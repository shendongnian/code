    public class Example
    {
      private ManualResetEventSlim allow = new ManualResetEventSlim();
    
      public void Start()
      {
        Task.Factory.StartNew(WorkerThread, TaskCreationOptions.LongRunning); 
      }
    
      public void Pause()
      {
        allow.Reset();
      }
    
      public void Resume()
      {
        allow.Set();
      }
    
      private void WorkerThread()
      {
        while (true)
        {
          allow.Wait(); // Wait at a safe point.
          lock (...)
          {
            // Your database operation goes here.
          }
        }
      }
    }
