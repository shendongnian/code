    public class Downloader
    {
        public event EventHandler DownloadProgress;
        DownloaderEventArgs downloaderEventArgs;
        public void DownloadStarted(DownloaderEventArgs e)
        {
            EventHandler downloadProgress = DownloadProgress;
            if (downloadProgress != null)
                downloadProgress(this, e);
        }
        // ...
    }
    class DownloaderEventArgs : EventArgs
    {
        public string Filename { get; private set; }
        public int Progress { get; private set; }
        public DownloaderEventArgs(int progress, string filename)
        {
            Progress = progress;
            Filename = filename;
        }
        public DownloaderEventArgs(int progress) : this(progress, String.Empty)
        {
            Progress = progress;
        }
    }
