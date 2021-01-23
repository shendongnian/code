    List<Task> allTasks = new List<Task>();
    foreach (var line in lines)
    {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                HttpClient client = new HttpClient(httpClientHandler);
                try
                {
                allTasks.Add(client.GetAsync(line).
                ContinueWith(t => t.Result.Content.ReadAsByteArrayAsync(), TaskContinuationOptions.OnlyOnRanToCompletion));
                }
                catch
                {
                }
    }
    await Task.WhenAll(allTasks);
