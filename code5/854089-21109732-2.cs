    public void DownloadAndPrintImagesAsync(IEnumerable<string> urls)
    {
        ThreadPool.QueueUserWorkItem(o =>
        {
            var images = urls.Select(url => DownloadImage(url));
            Dispatcher.Invoke(new Action(() => PrintImages(images)));
        });
    }
    private BitmapImage DownloadImage(string url)
    {
        var buffer = new WebClient().DownloadData(url);
        var image = new BitmapImage();
        using (var stream = new MemoryStream(buffer))
        {
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();
        }
        image.Freeze();
        return image;
    }
    private void PrintImages(IEnumerable<BitmapImage> images)
    {
        // print here
    }
