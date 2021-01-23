    Task<string>[] tasks = new Task<string>()[max];
    for (int i = 0; i < max; i++)
    {
        tasks[i] = GetMyDataAsync(i);
    }
    Task.WaitAll(tasks);
    foreach(var task in tasks)
        stringBuilder.Append(task.Result);
