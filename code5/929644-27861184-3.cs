    BitmapImage bitmapImage = null;
    using (System.IO.MemoryStream memory = new System.IO.MemoryStream())
    {
        bitmapImage = new BitmapImage();
        bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
        memory.Position = 0;
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = memory;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.EndInit();
    }
