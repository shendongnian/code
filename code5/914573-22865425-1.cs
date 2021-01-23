    var task = DoWorkAsync();
    QueueAsync(task);
    
    // ...
    async void QueueAsync(Task task)
    {
        // keep failed/cancelled tasks in the list
        // they will be observed outside
        _pendingTasks.Add(task);
        try
        {
            await task;
        }
        catch
        {
            return;
        }
        _pendingTasks.Remove(tasks)
    }
