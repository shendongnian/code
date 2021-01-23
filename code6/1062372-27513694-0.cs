    private void FetchImage(Uri uri)
    {
        var context = SynchronizationContext.Current;
        var image = new BitmapImage();
        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnDemand;
        image.UriSource = uri;
        image.DownloadFailed += image_DownloadFailed;
        image.DownloadCompleted += (s, args) =>
        {
            image.Freeze();
            context.Post(_ => image1.Source = image, null);
        };
        image.EndInit();
    }
