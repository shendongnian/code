    var webClient = new WebClient();
    var url = ((currentDevice as AUDIO).AlbumArt;
    var bitmap = new BitmapImage();
    using (var stream = new MemoryStream(webClient.DownloadData(url)))
    {
        bitmap.BeginInit();
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.StreamSource = stream;
        bitmap.EndInit();
    }
 
    image.Source = bitmap;
