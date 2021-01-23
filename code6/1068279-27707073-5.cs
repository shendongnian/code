    var tasks = URLsToProcess..Select(uri => DownloadStringAsTask(new Uri(uri))).ToArray();
    try
    {
        Task.WaitAll(tasks);
    }
    catch
    {
        // Handle exceptions
    }
    var results = tasks.Where(t => t.Status == TaskStatus.RanToCompletion).Select(t => t.Result);
