    try
    {
        while (tasks.Count() > 0)
        {
           var task = await Task.WhenAny(tasks);
           if (task.IsCanceled)
           {
              cancellationTokenSource.Cancel();
           }
    
           tasks.Remove(task);
        }
    }
