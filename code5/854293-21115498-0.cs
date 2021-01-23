    private void ImageDownloadCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
        if (!e.Cancelled && e.Error == null)
        {
            var url = (string)e.UserState;
            ...
        }
    }
