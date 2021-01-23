    List<Task> allTasks = new List<Task>();
    foreach (var line in lines)
    {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                HttpClient client = new HttpClient(httpClientHandler);
                allTasks.Add(client.GetAsync(line).
                ContinueWith(t => t.Result.Content.ReadAsByteArrayAsync()));
    }
    await Task.WhenAll(allTasks);
