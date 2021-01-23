    // Now if we finally have a task, run it.  If the task
    // was associated with one of the round-robin schedulers, we need to use it
    // as a thunk to execute its task.
    if (targetTask != null)
    {
        if (queueForTargetTask != null)
        {
            queueForTargetTask.ExecuteTask(targetTask);
            queueForTargetTask.Release();
        }
        else
        {
            TryExecuteTask(targetTask);
        }
    }
