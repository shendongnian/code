    var drawingVisual = new DrawingVisual();
    var drawingContext = drawingVisual.RenderOpen();
    drawingContext.DrawImage(BitmapSource.Create(colorFrame.Width, colorFrame.Height, 96, 96, PixelFormats.Bgr32, null, colorData, colorFrame.Width * colorFrame.BytesPerPixel), 
                              new Rect(new Size(colorFrame.Width, colorFrame.Height)));
    var overlayImage = new BitmapImage(new Uri("Images/boxbag.jpg"));
    drawingContext.DrawImage(overlayImage, 
                              new Rect(x, y, overlayImage.Width, overlayImage.Height));
    drawingContext.Close();
    var mergedImage = new RenderTargetBitmap(colorFrame.Width, colorFrame.Height, 96, 96, PixelFormats.Pbgra32);
    mergedImage.Render(drawingVisual);
    KinectVideo.Source = mergedImage;
