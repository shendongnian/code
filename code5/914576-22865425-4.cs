    var task = DoWorkAsync();
    QueueAsync(task).Forget();
    
    // ...
    async Task QueueAsync(Task task)
    {
        // keep failed/cancelled tasks in the list
        // they will be observed outside
        _pendingTasks.Add(task);
        await task;
        _pendingTasks.Remove(tasks)
    }
