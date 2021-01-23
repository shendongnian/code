    protected override void QueueTask(Task task)
    {
        var method = new Func<bool>(delegate
            {
                bool success = TryExecuteTask(task);
                if (task.IsFaulted)
                {
                    throw new Exception("Invoke", task.Exception);
                }
                return success;
            });
        _dispatcher.BeginInvoke(method);
    }
