    _executeTask = executeMethod(parameter);
    _executeTask.ContinueWith(x =>
    {
        Dispatcher.CurrentDispatcher.Invoke(new Action<Task>((task) =>
        {
            if (task.Exception != null)
               throw task.Exception.Flatten().InnerException;
        }), x);
    }, TaskContinuationOptions.OnlyOnFaulted);
