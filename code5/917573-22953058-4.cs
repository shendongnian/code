    private Bitmap ImageToBitmap(System.Windows.Controls.Image image)
    {
        RenderTargetBitmap rtBmp = new RenderTargetBitmap((int)image.ActualWidth, (int)image.ActualHeight,
            96.0, 96.0, PixelFormats.Pbgra32);
     
        image.Measure(new System.Windows.Size((int)image.ActualWidth, (int)image.ActualHeight));
        image.Arrange(new Rect(new System.Windows.Size((int)image.ActualWidth, (int)image.ActualHeight)));
     
        rtBmp.Render(image);
     
        PngBitmapEncoder encoder = new PngBitmapEncoder();
        MemoryStream stream = new MemoryStream();
        encoder.Frames.Add(BitmapFrame.Create(rtBmp));
     
        // Save to memory stream and create Bitamp from stream
        encoder.Save(stream);
     
        return new System.Drawing.Bitmap(stream);
    }
