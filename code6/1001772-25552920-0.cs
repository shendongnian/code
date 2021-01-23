    private static ImageSource CombineImageWithOverlay(byte[] imageBytes, byte[] overlayBytes)
    {
        var image = GetImageFromBytes(imageBytes);
        var overlay = GetImageFromBytes(overlayBytes);
        var visual = new DrawingVisual();
        using (var context = visual.RenderOpen())
        {
            context.DrawImage(image, new Rect(0, 0, image.PixelWidth, image.PixelHeight));
            context.DrawImage(overlay, new Rect(0, 0, overlay.PixelWidth, overlay.PixelHeight));
        }
        var result = new RenderTargetBitmap(image.PixelWidth, image.PixelHeight, image.DpiX, image.DpiY, PixelFormats.Pbgra32);
        result.Render(visual);
        return result;
    }
    
    private static BitmapImage GetImageFromBytes(byte[] bytes)
    {
        using (var stream = new MemoryStream(bytes))
        {
            var img = new BitmapImage();
            img.BeginInit();
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.StreamSource = stream;
            img.EndInit();
            return img;
        }
    }
