        FrameworkElement element = myControl.Content;
    // you can set the size as you need.
    Size theTargetSize = new Size(1500,2000)
    element.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
    element.Arrange(new Rect(theTargetSize ));
    // to affect the changes in the UI, you must call this method at the end to apply the new changes
    element.UpdateLayout();
    
    double dpiScale = 300.0 / 96;
    
    double dpiX = 300.0;
    double dpiY = 300.0;
    RenderTargetBitmap bmp = new RenderTargetBitmap(Convert.ToInt32(
    (theTargetSize .Width) * dpiScale),
    Convert.ToInt32((theTargetSize .Height) * dpiScale),
    dpiX, dpiY, PixelFormats.Pbgra32);
    
    bmp.Render(element);
    
    element.Measure(new System.Windows.Size());
    element.Arrange(new Rect());
    element.UpdateLayout();
    
    System.Windows.Media.Imaging.BitmapEncoder encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
    MemoryStream myStream = new MemoryStream();
    encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(this.CreateRenderTargetBitmap()));
    encoder.Save(myStream);
    var img = System.Drawing.Bitmap.FromStream(myStream);
    
    Bitmap bmp = new Bitmap((int)theTargetSize .Width, (int)theTargetSize .Height);
    
    var g = Graphics.FromImage(bmp);
    g.Clear(System.Drawing.Color.White);
    
    g.DrawImage(this.GetPageAsImage(), (int)this.Margin.Left, (int)this.Margin.Top);
    fileName = @”D:\myImage.png”;
    bmp.Save(fileName);
