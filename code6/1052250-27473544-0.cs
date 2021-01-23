    private async Task CancelAll()
    {
        // Get all running operations.
        var downloads = await BackgroundDownloader.GetCurrentDownloadsAsync();
        Debug.WriteLine(downloads.Count);
        var cancellationTokenSource = new CancellationTokenSource();
        List<Task> tasks = new List<Task>();
        foreach (var download in downloads)
        {
            var task = download.AttachAsync().AsTask(cancellationTokenSource.Token);
            tasks.Add(task);
        }
        try
        {
            // Cancel all the operations. It is expected they will throw exception.
            cancellationTokenSource.Cancel();
            Task.WaitAll(tasks.ToArray());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        Debug.WriteLine("All canceled!");
    }
