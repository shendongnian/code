    private void ResizeImage(string inputPath, string outputPath, int width, int height)
    {
        var bitmap = new BitmapImage();
        using (var stream = new FileStream(inputPath, FileMode.Open))
        {
            bitmap.BeginInit();
            bitmap.DecodePixelWidth = width;
            bitmap.DecodePixelHeight = height;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = stream;
            bitmap.EndInit();
        }
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        using (var stream = new FileStream(outputPath, FileMode.Create))
        {
            encoder.Save(stream);
        }
    }
