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
        ActiveDownloadJob adJob = e.UserState as ActiveDownloadJob;
        ProgressBar pb = (adJob != null) ? adJob.ProgressBar : null;
        lock (_downloadQueue)
        {
            if (_downloadQueue.Count == 0)
            {
                if (pb != null) pb.Tag = null;
            }
            else
            {
                DownloadData dd = _downloadQueue.Dequeue();
                StartDownloadWithProgressBar(dd, pb);
            }
        }
    }
