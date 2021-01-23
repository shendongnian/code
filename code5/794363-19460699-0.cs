    WebClient wc = new WebClient();
    wc.DownloadFileWithTimeout(url, filename, 20000);
 
    public static class SOExtensions
    {
        public static void DownloadFileWithTimeout(this WebClient wc, string url, string file, int timeout)
        {
            var tcs = new TaskCompletionSource<bool>();
            var bgTask = Task.Factory.StartNew(() =>
            {
                wc.DownloadFileTaskAsync(url, file).Wait();
                tcs.TrySetResult(true);
            });
            if (!bgTask.Wait(timeout))
            {
                throw new TimeoutException("Timed out while downloading \"" + url + "\"");
            }
        }
    }
