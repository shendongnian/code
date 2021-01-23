    private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        IEnumerable<string> enumerable = your urls here;
        var results = new List<Tuple<string, string, Exception>>();
        await enumerable.ForEachAsync(s => DownloadFileTaskAsync(s, null, 1000), (url, t) => results.Add(t));
    }
    
    /// <summary>
    ///     Downloads a file from a specified Internet address.
    /// </summary>
    /// <param name="remotePath">Internet address of the file to download.</param>
    /// <param name="localPath">
    ///     Local file name where to store the content of the download, if null a temporary file name will
    ///     be generated.
    /// </param>
    /// <param name="timeOut">Duration in miliseconds before cancelling the  operation.</param>
    /// <returns>A tuple containing the remote path, the local path and an exception if one occurred.</returns>
    private static async Task<Tuple<string, string, Exception>> DownloadFileTaskAsync(string remotePath,
        string localPath = null, int timeOut = 3000)
    {
        try
        {
            if (remotePath == null)
            {
                Debug.WriteLine("DownloadFileTaskAsync (null remote path): skipping");
                throw new ArgumentNullException("remotePath");
            }
    
            if (localPath == null)
            {
                Debug.WriteLine(
                    string.Format(
                        "DownloadFileTaskAsync (null local path): generating a temporary file name for {0}",
                        remotePath));
                localPath = Path.GetTempFileName();
            }
    
            using (var client = new WebClient())
            {
                TimerCallback timerCallback = c =>
                {
                    var webClient = (WebClient) c;
                    if (!webClient.IsBusy) return;
                    webClient.CancelAsync();
                    Debug.WriteLine(string.Format("DownloadFileTaskAsync (time out due): {0}", remotePath));
                };
                using (var timer = new Timer(timerCallback, client, timeOut, Timeout.Infinite))
                {
                    await client.DownloadFileTaskAsync(remotePath, localPath);
                }
                Debug.WriteLine(string.Format("DownloadFileTaskAsync (downloaded): {0}", remotePath));
                return new Tuple<string, string, Exception>(remotePath, localPath, null);
            }
        }
        catch (Exception ex)
        {
            return new Tuple<string, string, Exception>(remotePath, null, ex);
        }
    }
    public static class Extensions
    {
        public static Task ForEachAsync<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, Task<TResult>> taskSelector, Action<TSource, TResult> resultProcessor)
        {
            var oneAtATime = new SemaphoreSlim(5, 10);
            return Task.WhenAll(
                from item in source
                select ProcessAsync(item, taskSelector, resultProcessor, oneAtATime));
        }
        private static async Task ProcessAsync<TSource, TResult>(
            TSource item,
            Func<TSource, Task<TResult>> taskSelector, Action<TSource, TResult> resultProcessor,
            SemaphoreSlim oneAtATime)
        {
            TResult result = await taskSelector(item);
            await oneAtATime.WaitAsync();
            try
            {
                resultProcessor(item, result);
            }
            finally
            {
                oneAtATime.Release();
            }
        }
    }
