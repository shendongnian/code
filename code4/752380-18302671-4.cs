    var webClient = new WebClient();
    var url = ((currentDevice as AUDIO).AlbumArt;
    using (var stream = new MemoryStream(webClient.DownloadData(url)))
    {
        var bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.StreamSource = stream;
        bitmap.EndInit();
        image.Source = bitmap;
    }
