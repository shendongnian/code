    BitmapSource ImageToBitmapSource(System.Drawing.Image image)
    {
        using(MemoryStream memory = new MemoryStream())
        {
            image.Save(memory, ImageFormat.Bmp);
            memory.Position = 0;
            var source = new BitmapImage();
            source.BeginInit();
            source.StreamSource = memory;
            source.CacheOption = BitmapCacheOption.OnLoad;
            source.EndInit();
            return source;
        }
    }
