    startfunction()
    {
        Task[] tasks = new Task[250];
        start1step(tasks);
        Task.WaitAll(tasks);
    }
    private void start1step(Task[] tasks)
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            int taskParam = i;
            tasks[i] = Task.Run(() => WorkThreadFunction(taskParam));
        }
    }
    public void WorkThreadFunction(int x)
    {
        try
        {
            // do some background work
        }      
        catch
        {
            //
        } 
    }
