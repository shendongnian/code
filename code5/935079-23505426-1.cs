    var task = Task.Run(() => {
        throw new ApplicationException("I'll throw an unhandled exception"); });
    Thread.Sleep(1000);
    if (task.IsFaulted)
      Console.WriteLine(task.Exception.InnerException.Message);
