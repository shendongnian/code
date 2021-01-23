    var bitmap = new BitmapImage();
    using (var stream = new MemoryStream(webClient.DownloadData(url)))
    {
        bitmap.BeginInit();
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.StreamSource = stream;
        bitmap.EndInit();
    }
    bitmap.Freeze();
    image.Dispatcher.Invoke((Action)(() => image.Source = bitmap));
