    try
    {
        while (tasks.Count() > 0)
        {
           var task = await Task.WhenAny(tasks);
           if (task.IsCanceled || task.IsFaulted)
           {
              cancellationTokenSource.Cancel();
              // Do something with the exception message by accessing
              // task.Exception.
           }
    
           tasks.Remove(task);
        }
    }
