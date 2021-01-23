    public async void YourMethodAsync(IProgress<ProgressInfo> progressIndicator)
    {
        ProgressInfo pi = new ProgressInfo(0);
        ...
        // Report progress.
        pi.PrecentageComplete = 30;
        progressIndicator.Report(pi);
        ...
    }
