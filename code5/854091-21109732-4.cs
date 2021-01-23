    private List<BitmapImage> images = new List<BitmapImage>();
    private void DownloadAndPrintImagesAsync(IEnumerable<string> urls)
    {
        foreach (var url in urls)
        {
            var webClient = new WebClient();
            webClient.DownloadDataCompleted += ImageDownloadCompleted;
            webClient.DownloadDataAsync(new Uri(url));
        }
    }
    private void ImageDownloadCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
        if (!e.Cancelled && e.Error == null)
        {
            var image = new BitmapImage();
            using (var stream = new MemoryStream(e.Result))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
            }
            images.Add(image);
            if (images.Count == 2) // or whatever
            {
                // print images
            }
        }
    }
