    public async Task<T> WrapException<T>(Func<Task<T>> task)
    {
        var actualTask = task();
        await WrapException((Task)actualTask);
        return actualTask.Result;
    }
