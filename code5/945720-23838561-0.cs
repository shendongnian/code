    RunResult RunTask(Task task)
    {
        task.Wait();
        var genericTask = task as Task<RunResult>;
        return genericTask != null ? genericTask.Result : null;
    }
