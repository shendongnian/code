    public int StartNewTask(Action<CancellationToken> method)
    {
        try
        {
            CancellationToken ct = _cts.Token;
            Task task = Task.Factory.StartNew(method(ct), ct);
    
            _tasksCount++;
            _tasksList.Add(task.Id, task);
    
            return task.Id;
        }
        catch (Exception ex)
        {
            _logger.Error("Cannot execute task.", ex);
        }
    
        return -1;
    }
