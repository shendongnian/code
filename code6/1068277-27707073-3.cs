    var tasks = URLsToProcess..Select(uri => DownloadStringAsTask(new Uri(uri)))
    try
    {
        Task.WaitAll(tasks);
    }
    catch
    {
        var results = tasks.Where(t => t.Status == TaskStatus.RanToCompletion).Select(t => t.Result);
    }
