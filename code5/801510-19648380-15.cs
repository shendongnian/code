    private void StartDownloadWithProgressBar(ExtractImages.DownloadData downloadData, ProgressBar progressBar)
    {
        WebClient wc = new WebClient();
        wc.DownloadFileCompleted += DownloadCompletedCallback;
        wc.DownloadProgressChanged += DownloadProgressCallback;
        ActiveDownloadJob adJob = new ActiveDownloadJob(downloadData, progressBar, wc);
        progressBar.Tag = adJob;
        wc.DownloadFileAsync(
            downloadData.DownloadUri,
            downloadData.TargetPath,
            adJob
        );
    }
