    public void ProcessOrder()
    {
        // other stuff...
    
        // initiate the IO-bound operation
        var task = _publisher.PublishAsync(new ItemOrderedEvent() {});
        {
            MessageId = Guid.NewGuid(),
            IsDurable = true,
        }); // do not call .Wait() here
    
        // do your work
        for (var i = i; i < 100; i++)
            DoWorkItem(i);
    
        // work is done, wait for the result of the IO-bound operation
        task.Wait(); 
    }
