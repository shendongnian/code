    public void ResizeImage(string inputPath, string outputPath, int width, int height)
    {
        var bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.DecodePixelWidth = width;
        bitmap.DecodePixelHeight = height;
        bitmap.UriSource = new Uri(inputPath);
        bitmap.EndInit();
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        using (var stream = new FileStream(outputPath, FileMode.Create))
        {
            encoder.Save(stream);
        }
    }
