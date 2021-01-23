    using(FileStream Fs = new FileStream("path",FileMode.Open,FileAccess.Read))
    {
        
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = Fs;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.EndInit();
        image.source = bitmapImage;
    }
