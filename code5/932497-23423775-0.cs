    private static BitmapFrame CreateResizedImage(ImageSource source, int width, int height, int margin)
{
    var rect = new Rect(margin, margin, width - margin * 2, height - margin * 2);
    var group = new DrawingGroup();
    RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.HighQuality);
    group.Children.Add(new ImageDrawing(source, rect));
    var drawingVisual = new DrawingVisual();
    using (var drawingContext = drawingVisual.RenderOpen())
        drawingContext.DrawDrawing(group);
    var resizedImage = new RenderTargetBitmap(
        width, height,         // Resized dimensions
        96, 96,                // Default DPI values
        PixelFormats.Default); // Default pixel format
    resizedImage.Render(drawingVisual);
    return BitmapFrame.Create(resizedImage);
