    bool isAsync = false; // some flag to check for async operation
    var batch = Task.Factory.ContinueWhenAll(items.Select(p =>
    {
        return CreateItem(p);
    }).ToArray(), completedTasks => { Console.WriteLine("completed"); });
    if (isAsync)
        batch.Wait();
