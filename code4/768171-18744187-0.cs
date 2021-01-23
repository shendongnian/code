    class Parent
    {
      private ProducerConsumerQueue<YourData> queue;
    
      public Parent(ProducerConsumerQueue<YourData> pdq)
      {
        queue = pdq;
      }
    
      public void GenerateItems()
      {
        while (...)
        {
          YourData item = GenerateItem();
          queue.Produce(item);
        }
      }
    }
    
    class Child
    {
      public Child(ProducerConsumeQueue<YourData> pdq)
      {
        Task.Factory.StartNew(
          () =>
          {
            while (true)
            {
              YourData item = pdq.Consume();
              try
              {
                ProcessItem(item);
              }
              catch
              {
                // Do something with exceptions here.
              }
            }
          ), TaskCreationOptions.LongRunning);
      }
    
      private void ProcessItem(YourData item)
      {
        // Add logic to process each data item here.
      }
    
    }
    
    class ProducerConsumerQueue<T>
    {
      private BlockingCollection<T> queue = new BlockingCollection<T>();
    
      public void Produce(T item)
      {
        // This method queues an item and causes the Take method to return.
        queue.Add(item);
      }
    
      public T Consume()
      {
        // This method blocks without polling if the collection is empty.
        return queue.Take();
      }
    
    }
