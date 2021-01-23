    // somewhere in initialization
    bitmapImage.DownloadProgress += new EventHandler<DownloadProgressEventArgs>(bi_DownloadProgress);
    bitmapImage.ImageOpened += new EventHandler<ExceptionRoutedEventArgs>(bi_ImageOpened);
    ...
    //progressBar is an existing control defined in XAML or extracted from a XAML template
    void bi_DownloadProgress(object sender, DownloadProgressEventArgs e)
    {
        progressBar.Value = e.Progress;
    }
    void bi_ImageOpened(object sender, RoutedEventArgs e)
    {
        progressBar.Visibility = Visibility.Collapsed;
    }
