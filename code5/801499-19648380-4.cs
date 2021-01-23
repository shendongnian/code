    private void DownloadCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
             ... download cancelled...
        }
        else if (e.Error != null)
        {
             ... download failed...
        }
        ProgressBar pb = e.UserState as ProgressBar;
        
        lock (_downloadQueue)
        {
            if (_downloadQueue.Count == 0)
            {
                if (pb != null) pb.Tag = null;
            }
            else
            {
                DownloadData dd = _downloadQueue.Dequeue();
                if (pb != null) pb.Tag = dd;
                _webClient.DownloadFileAsync(
                    dd.DownloadUri,
                    dd.TargetPath,
                    e.UserState
                );
            }
        }
    }
