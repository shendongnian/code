    static async Task<string> DownloadAllAsync(IEnumerable<string> urls)
    {
        var httpClient = new HttpClient();
        IEnumerable<Task<Task<string>>> downloads = urls.Select(url => httpClient.GetStringAsync(url).ContinueWith(p=> p, TaskContinuationOptions.ExecuteSynchronously));
        Task<Task<string>>[] downloadTasks = downloads.ToArray();
        Task<string>[] compleTasks =  await Task.WhenAll(downloadTasks);
        foreach (var task in compleTasks)
        {
            if (task.IsFaulted)//Or task.IsCanceled
            {
                //Handle it
            }
        }
        var htmlPages = compleTasks.Where(x => x.Status == TaskStatus.RanToCompletion)
            .Select(x => x.Result);
        
        return string.Concat(htmlPages);
    }
