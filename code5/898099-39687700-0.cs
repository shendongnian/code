    _executeTask = executeMethod(parameter);
    _executeTask.ContinueWith(x =>
    {
        Dispatcher.CurrentDispatcher.Invoke(new Action<Task>((task) =>
        {
            if (x.Exception != null)
                throw x.Exception.Flatten().InnerException;
        }), x);
    }, TaskContinuationOptions.OnlyOnFaulted);
