    public BitmapImage ToImage(byte[] array)
    {
        using (var ms = new System.IO.MemoryStream(array))
        {
        var image = new BitmapImage();
        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnLoad; // here
        image.StreamSource = ms;
        image.EndInit();
        return image;
        }
    }
