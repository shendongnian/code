    private void StartDownloadsAsync()
    {
        var downloadQueue = new Queue<DownloadOperation>();
        // Create all the download operations and add them to the queue.
        await CreateDownloadsAsync();
        var maxConcurrentDownloads = 4;
        var loopAmount = Math.Min( maxConcurrentDownloads, downloadQueue.Count );
        for( var i = 0; i < loopAmount; i++ )
        {
            DownloadAsync();
        }
    }
    
    private void DownloadAsync()
    {
        var download = downloadQueue.Dequeue();
    
        HandleDownloadAsync( download ).ContinueWith( task => DownloadComplete( download ) );
    }
    
    private void DownloadComplete( DownloadOperation download )
    {
        // Update progress counter here.
    
        if( downloadQueue.Count > 0 )
        {
            DownloadAsync();
        }
        else
        {
            // Downloads are done. Do something.
        }
    }
    
    private async Task HandleDownloadAsync( DownloadOperation download, bool isActive = false )
    {
        if( !isActive )
        {
            await download.StartAsync().AsTask( cancellationTokenSource.Token );
        }
        {
            await download.AttachAsync().AsTask( cancellationTokenSource.Token );
        }
    }
