    Task[] tasks = new Task[proxies.Count];
    
    for (int i = 0; i < proxies.Count; i++)
    {
        string tmp = proxies[i];
        tasks[i] = checkProxyAsync(tmp);
    }
    
    await Task.WhenAll(tasks);
