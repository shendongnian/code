    System.Drawing.Bitmap bitmap = ...
    var bitmapImage = new BitmapImage();
    using (var memoryStream = new MemoryStream())
    {
        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
        bitmapImage.BeginInit();
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.StreamSource = memoryStream;
        bitmapImage.EndInit();
    }
    var image = new Image
    {
        Source = bitmapImage,
        Stretch = Stretch.None
    };
    doc.Blocks.Add(new BlockUIContainer(image));
