    public static BitmapSource RenderToBitmap(
        this UIElement element, double scale, Brush background)
    {
        var renderWidth = (int)(element.RenderSize.Width * scale);
        var renderHeight = (int)(element.RenderSize.Height * scale);
        var renderTarget = new RenderTargetBitmap(renderWidth, renderHeight,
                                                  96, 96, PixelFormats.Default);
        var sourceBrush = new VisualBrush(element);
        var drawingVisual = new DrawingVisual();
        var drawingContext = drawingVisual.RenderOpen();
        var rect = new Rect(0, 0, element.RenderSize.Width, element.RenderSize.Height);
        using (drawingContext)
        {
            drawingContext.PushTransform(new ScaleTransform(scale, scale));
            drawingContext.DrawRectangle(background, null, rect); // here
            drawingContext.DrawRectangle(sourceBrush, null, rect);
        }
        renderTarget.Render(drawingVisual);
        return renderTarget;
    }
