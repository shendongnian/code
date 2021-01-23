    public static Task EnsureStarted(this Task task)
    {
        if (task.Status == TaskStatus.Created)
        {
            try
            {
                task.Start();
            }
            catch (InvalidOperationException) { }
        }
        return task;
    }
