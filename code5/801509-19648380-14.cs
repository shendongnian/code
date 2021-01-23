    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        lock(_downloadQueue)
        {
            AddImageDownloadsToQueue(_downloadQueue, StartTags, LastTags, Maps, localFilename, UrlsPath);
            if (_downloadQueue.Count > 0)
                foreach (ProgressBar pb in progressbars)
                {
                    if (pb.Tag == null)
                    {
                        DownloadData dd = _downloadQueue.Dequeue();
                        StartDownloadWithProgressBar(dd, pb);
                        if (_downloadQueue.Count == 0) break;
                    }
                }
        }
    }
