    Image yourImageObject = new Image();
    yourImageObject.Source = yourImageSource;
    RenderTargetBitmap renderTargetBitmap = 
        new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
    renderTargetBitmap.Render(yourImageObject);
    // Save to .png file
    PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();    
    pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));    
    using (Stream stream = File.Create(filepath))    
    {    
        pngBitmapEncoder.Save(stream);    
    }
