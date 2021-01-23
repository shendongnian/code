    int Height = (int)myCanvas.ActualHeight;
    int Width = (int)myCanvas.ActualWidth;
    RenderTargetBitmap bmp = new RenderTargetBitmap(Width, Height, 96, 96, PixelFormats.Pbgra32);
    bmp.Render(myCanvas);
    string file = filename; //asuming you pass the file as an argument
    string Extension = System.IO.Path.GetExtension(file).ToLower();
    BitmapEncoder encoder;            
    if (Extension == ".gif") 
        encoder = new GifBitmapEncoder();            
    else if (Extension == ".png")
        encoder = new PngBitmapEncoder();            
    else if (Extension == ".jpg")
        encoder = new JpegBitmapEncoder();            
    else
        return;
    encoder.Frames.Add(BitmapFrame.Create(bmp));
    using (Stream stm = File.Create(file))
    {
        encoder.Save(stm);
    }
    
