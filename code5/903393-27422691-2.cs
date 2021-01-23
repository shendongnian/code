    public interface IDownload
    {
        event EventHandler<DownloadStateEventArgs> StateChanged;
        event EventHandler<DownloadStateEventArgs> Completed;
    
        DownloadState State { get; }
        Guid Id { get; }
        string Uri { get; }
        long Filesize { get; }
        long Downloaded { get; }
    
        Task DownloadAsync();
    }
