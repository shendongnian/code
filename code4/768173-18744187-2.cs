    class Producer
    {
      private BlockingCollection<YourData> queue;
    
      public Producer(BlockingCollection<YourData> q)
      {
        queue = q;
      }
    
      public void GenerateItems()
      {
        while (...)
        {
          YourData item = GenerateItem();
          queue.Add(item);
        }
      }
    }
    
    class Consumer
    {
      public Consumer(BlockingCollection<YourData> queue)
      {
        Task.Factory.StartNew(
          () =>
          {
            foreach (YourData item in queue.GetConsumingEnumerable())
            {
              ProcessItem(item);
            }
          ), TaskCreationOptions.LongRunning);
      }
    
      private void ProcessItem(YourData item)
      {
        // Add logic to process each data item here.
      }
    
    }
    
