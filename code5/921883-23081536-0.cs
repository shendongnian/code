    public void ProcessOrder()
    {
      // other stuff...
      Task.Run(async () => await _publisher.PublishAsync(new ItemOrderedEvent()
      {
        MessageId = Guid.NewGuid(),
        IsDurable = true,
      }).ContinueWith((Task task) => //do continuation if you need);
