    var block = new ActionBlock<object>(async item =>
    {
      // Handle synchronous item
      var action = item as Action;
      if (action != null)
        action();
      // Handle asynchronous item
      var func = item as Func<Task>;
      if (func != null)
        await func();
    });
    // To queue a synchronous item
    Action synchronous = () => Thread.Sleep(1000);
    block.Post(synchronous);
    // To queue an asynchronous item
    Func<Task> asynchronous = async () => { await Task.Delay(1000); };
    blockPost(asynchronous);
