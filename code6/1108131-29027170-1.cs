    public GenericPictureName(string name, string image)
    {
        Name = name;
        var bitmapImage = new BitmapImage();
        var imageBuffer = new WebClient().DownloadData(image);
        using (var ms = new MemoryStream(imageBuffer))
        {
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = ms;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
        }
        bitmapImage.Freeze();
        ImgSource = bitmapImage;
    }
