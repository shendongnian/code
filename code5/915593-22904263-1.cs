    using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
    {
        BitmapImage image = new BitmapImage();
        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.StreamSource = fs;
        image.EndInit();
        image.Freeze();
        return image;
    }
