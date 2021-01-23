    ImageSource image = new BitmapImage(new Uri(@"..\..\5c5f910416e2b92bb73fa59c56fe695d.png", UriKind.Relative));
    var brush = new ImageBrush(image);
    var pen = new Pen(brush, 50);
    var drawingVisual = new DrawingVisual();
    using (DrawingContext drawingContext = drawingVisual.RenderOpen())
    {
        drawingContext.DrawRectangle(null, pen, new Rect(new Size(200, 200)));
    }
    var renderTargetBitmap = new RenderTargetBitmap(200, 200, 96, 96, PixelFormats.Pbgra32);
    renderTargetBitmap.Render(drawingVisual);
    Content = new Image {Source = renderTargetBitmap, Stretch = Stretch.None};
