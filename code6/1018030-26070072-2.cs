    var tasks = new Task<string>[count];
    for (int i = 0; i < count; i++)
    {
        tasks[i] = MyHttpClient.GetVersion(port, method);
    }
    var results = await Task.WhenAll(tasks);
