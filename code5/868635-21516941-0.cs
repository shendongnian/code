    public class ContentFetcher
    {
        Download download;
        public ContentFetcher(Download download)
        {
            this.download = download;
        }
        public void SomeOtherMethod()
        {
            // Don't create a new instance of Download - use the original instance
            // Download download = new Download();
            MessageBox.Show(download.DownloadLevel.ToString());     // Output is 0, it should 05
            MessageBox.Show(download.IsAudio.ToString());
        }
        ...
        ...
    }
