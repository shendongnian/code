    public async Task DisableFormsTillTasksComplete(Task[] tasks)
    {
        this.Enabled = false;
        await task.WhenAll(tasks);
        this.Enabled = true;
    }
