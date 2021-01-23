        void SaveToBmp(FrameworkElement visual, string fileName)
    {
        var encoder = new BmpBitmapEncoder();
        SaveUsingEncoder(visual, fileName, encoder);
    }
    
    void SaveToPng(FrameworkElement visual, string fileName)
    {
        var encoder = new PngBitmapEncoder();
        SaveUsingEncoder(visual, fileName, encoder);
    }
    
    // and so on for other encoders (if you want)
    
    
    void SaveUsingEncoder(FrameworkElement visual, string fileName, BitmapEncoder encoder)
    {
        RenderTargetBitmap bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
        bitmap.Render(visual);
        BitmapFrame frame = BitmapFrame.Create(bitmap);
        encoder.Frames.Add(frame);
    
        using (var stream = File.Create(fileName))
        {
            encoder.Save(stream);
        }
    }
