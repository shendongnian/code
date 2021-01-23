    using (var stream = new MemoryStream(webClient.DownloadData(url)))
    {
        var bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.StreamSource = stream;
        bitmap.EndInit();
        bitmap.Freeze();
        image.Dispatcher.Invoke((Action)(() => image.Source = bitmap));
    }
