    private ActionBlock<string> block = new ActionBlock<string>(
        message => dosomething(message),
        new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 5 });
    private void MyReceiveCompleted1(object sender, ReceiveCompletedEventArgs e)
    {
      var message = queue.EndReceive(e.AsyncResult);
      block.Post(message);
      autoResetEvent1.Set();
    }
