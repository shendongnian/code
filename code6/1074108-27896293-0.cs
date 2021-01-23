    private async void Foo()
    {
        var downloads = await BackgroundDownloader.GetCurrentDownloadsAsync();
        foreach (var download in downloads)
        {
            var task = download.AttachAsync().AsTask();
            var notAwait = task.ContinueWith(OnCompleted);
        }
    }
    private void OnCompleted(Task<DownloadOperation> task)
    {
        DownloadOperation download = task.Result;
        // ...
    }
