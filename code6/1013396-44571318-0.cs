    Task parent = Task.Factory.StartNew(() =>
    {
      Task child = Task.Factory.StartNew(
         () => { Console.WriteLine("foo"); },
         TaskCreationOptions.AttachedToParent);
      Task continuation = child.ContinueWith(
         (Task prev) => { throw new InvalidOperationException("Test"); },
         TaskContinuationOptions.AttachedToParent);
    });
    try
    {
      parent.Wait();
    }
    catch (AggregateException ex)
    {
      if (ex.Flatten().InnerException is InvalidOperationException)
      { 
        Console.WriteLine("The continuation exception was propagated to parent");
      }
    }
