    var visual = new DrawingVisual();
    using (var ctx = visual.RenderOpen())
    {
        foreach(BitmapFrame frame in decoder.Frames)
        {
            maximumWidth = Math.Max(maximumWidth, frame.PixelWidth);                     
            ctx.DrawImage(frame, new Rect(0, totalHeight, imageWidth, imageHeight));
            totalHeight = totalHeight + frame.PixelHeight;
        }
    }
    // Converts the Visual (DrawingVisual) into a BitmapSource
    var bmp = new RenderTargetBitmap(maximumWidth, totalHeight, 96, 96, PixelFormats.Pbgra32);
    bmp.Render(visual);
    // Finally, save the rendered bitmap as a jpeg to the output stream
    JpegBitmapEncoder enc = new JpegBitmapEncoder();
    enc.Frames.Add(BitmapFrame.Create(bmp));
    using (Stream output = new FileStream(outputFile, FileMode.Create))
    {
        enc.Save(output);
    }
