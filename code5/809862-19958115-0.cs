    public class Example
    {
      private NetworkStream networkstream = GetNetworkStream();
      private BlockingCollection<byte[]> queue = new BlockingCollection<byte[]>();
    
      public Example()
      {
        Task.Factory.StartNew(
          () =>
          {
            foreach (byte[] buffer in queue.GetConsumingEnumerable())
            {
              this.networkstream.Write(buffer, 0, buffer.Length);
            }
          }, TaskCreationOptions.LongRunning);
      }
    
      public void QueueWrite(byte[] buffer)
      {
        queue.Add(buffer);
      }
    }
