    var tasks = URLsToProcess.Select(uri => DownloadStringAsTask(new Uri(uri))).ToArray();
    while (tasks.Any())
    {
        try
        {
            Task.WaitAll(tasks);
            break;
        }
        catch (Exception e)
        {
            // handle exception/report progress...
            tasks = tasks.Where(t => t.Status != TaskStatus.Faulted).ToArray();
        }
    }
    var results = tasks.Select(t => t.Result);
