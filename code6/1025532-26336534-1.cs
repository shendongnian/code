    for (int i = 0; i < list.Count; i++)
    {
        var tuple = list[i];
        string url = tuple.Item2;
    
        int retryCount = 3;
        var httpClient = new HttpClient(); // should create new object for each req
        tasks[i] = httpClient.GetStringWithRetryAsync(url, retryCount).
            ContinueWith(task => {
            {
                //......
    
            });
    }
    Task.WaitAll(tasks);
