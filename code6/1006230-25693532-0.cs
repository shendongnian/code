    SomeAsyncMethod().ContinueWith(t =>
    {
        instance.Consumers.TryRemove(t.Id, out bogusTask);
    });
    instance.Consumers.TryAdd(newTask.Id, newTask);
