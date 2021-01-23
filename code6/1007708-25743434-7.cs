    Task<string>[] tasks = new Task<string>()[max];
    for (int i = 0; i < max; i++)
    {
        tasks[i] = GetMyDataAsync(i).ContinueWith(t => stringBuilder.Append(t.Result));
    }
    Task.WaitAll(tasks);
