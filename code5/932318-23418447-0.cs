    public static BitmapSource GetBitmapImage(Bitmap bitmap)
    {
        BitmapImage bitmapImage = new BitmapImage();
        using (MemoryStream stream = new MemoryStream())
        {
            bitmap.Save(stream, ImageFormat.Png);
            stream.Position = 0;
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = stream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
        }
        return bitmapImage;
    }
