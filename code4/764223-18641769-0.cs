    public class PCQueue
    {
      private Thread[] workers;
      private BlockingCollection<Action> queue = new BlockingCollection<Action>();
      private CancellationTokenSource cts = new CancellationTokenSource();
    
      public PCQueue(int workerCount)
      {
        workers = new Thread[workerCount];
        for (int i = 0; i < workerCount; i++)
        {
          workers[i] = new Thread(Run);
          workers[i].Start();
        }
      }
    
      public void Shutdown(bool waitForWorkers)
      {
        cts.Cancel();
        if (waitForWorkers)
        {
          foreach (Thread thread in workers)
          {
            thread.Join();
          }
        }
      }
    
      public void EnqueueItem(Action action)
      {
        queue.Add(action);
      }
    
      private void Consumer()
      {
        while (true)
        {
          Action action = queue.Take(cts.Token);
          try
          {
            if (action != null) action();
          }
          catch (Exception caught)
          {
            // Notify somebody that something bad happened.
          }
        }
      }
    }
