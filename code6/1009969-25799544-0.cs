    DrawingVisual drawingVisual = new DrawingVisual();
    DrawingContext drawingContext = drawingVisual.RenderOpen();
    // Let's draw a rectangle!
    var gradientBrush = new LinearGradientBrush();
    gradientBrush.GradientStops.Add(new GradientStop(Colors.Azure, 0.0));
    gradientBrush.GradientStops.Add(new GradientStop(Colors.SteelBlue, 1.0));
    drawingContext.DrawRectangle(gradientBrush, null, new Rect(0, 0, _imageWidth, _imageHeight));
    drawingContext.Close();
    // Now to save it
    RenderTargetBitmap bmp = new RenderTargetBitmap(_imageWidth, _imageHeight, 96, 96, PixelFormats.Pbgra32);
    bmp.Render(drawingVisual);
    PngBitmapEncoder png = new PngBitmapEncoder();
    png.Frames.Add(BitmapFrame.Create(bmp));
    byte[] imageBinary = null;
    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    {
        png.Save(memoryStream);
        imageBinary = memoryStream.GetBuffer();
    }
    
