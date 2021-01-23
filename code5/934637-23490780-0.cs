    // use the same CancellationTokenSource to create all tasks
    var tokenSource2 = new CancellationTokenSource();
    // for each task, use the following structure
    CancellationToken ct = tokenSource2.Token;
    
    var task = Task.Factory.StartNew(() =>
    {
      // Were we already canceled?
      ct.ThrowIfCancellationRequested();
      bool moreToDo = true;
      // make sure any loops and other methods check the ct.IsCancellationRequested regularly
      while (moreToDo)
      {
        if (ct.IsCancellationRequested)
        {
          // Clean up any resources, transactions etc. here, then...
          ct.ThrowIfCancellationRequested();
        }
      }
    }, tokenSource2.Token); // Pass same token to StartNew.
    // add each task to the tasks list    
    tasks.Add(task);
    // once all tasks created, wait on them and cancel if they overrun
    //   by passing the token, another thread could even cancel the whole operation ahead of time
    if (!Task.WaitAll(tasks.ToArray(), (int)TimeSpan.FromMinutes(30).TotalMilliseconds, 
      tokenSource2.Token)) 
    {      
      // did not finish in the 30 minute timespan, so kill the threads
      tokenSource2.Cancel();
      try
      {
        //    Now wait for the tasks to cancel
        Task.WaitAll(tasks.ToArray());
      }
      catch (AggregateException ae)
      {
        // handle any unexpected task exceptions here
      }
    }
    
