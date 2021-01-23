    ProgressIndicator progress = new ProgressIndicator
    {
        IsVisible = true,
        IsIndeterminate = true,
        Text = "Downloading details..."
    };
    SystemTray.SetProgressIndicator(this, progress);
