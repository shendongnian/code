    RunResult RunTask(Task task)
    {
        task.Wait();
        var type = task.GetType();
        if (!type.IsGenericType)
        {
            return null;
        }
        //Could also use: ((dynamic)task).Result as RunResult
        return type.GetProperty("Result").GetValue(task) as RunResult;
    }
