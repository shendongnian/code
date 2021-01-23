    public async Task ProcessOrder()
    {
      // other stuff...
     await _publisher.PublishAsync(new ItemOrderedEvent()
     {
        MessageId = Guid.NewGuid(),
        IsDurable = true,
     });
    }  
