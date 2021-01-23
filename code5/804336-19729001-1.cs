    public class YourForm : Form
    {
      private CancellationTokenSource cts = new CancellationTokenSource();
      private ConcurrentQueue<YourData> queue = new ConcurrentQueue<YourData>();
    
      private void YourForm_Load(object sender, EventArgs args)
      {
        Task.Factory.StartNew(Worker, TaskCreationOptions.LongRunning);
      }
    
      private void UpdateTimer_Tick(object sender, EventArgs args)
      {
        YourData item;
        while (queue.TryDequeue(out item))
        {
          // Update the chart here.
        }
      }
    
      private void Worker()
      {
        CancellationToken cancellation = cts.Token;
        while (!cancellation.WaitHandle.WaitOne(YOUR_POLLING_INTERVAL))
        {
          YourData item = GetData();
          queue.Enqueue(item);
        }
      }   
    }
