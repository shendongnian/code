    var tasks = URLsToProcess..Select(uri => DownloadStringAsTask(new Uri(uri)))
    try
    {
        await Task.WhenAll(tasks);
    }
    catch
    {
        var results = Task.WhenAll(tasks.Where(t => t.Status == TaskStatus.RanToCompletion)).Result;
    }
