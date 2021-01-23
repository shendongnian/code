    void myKinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
    {
        using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
        {
            if (colorFrame == null) return;
    
            if (colorData == null)
                colorData = new byte[colorFrame.PixelDataLength];
    
            colorFrame.CopyPixelDataTo(colorData);
    
            if (colorImageBitmap == null)
            {
                this.colorImageBitmap = new WriteableBitmap(
                    colorFrame.Width,
                    colorFrame.Height,
                    96,  // DpiX
                    96,  // DpiY
                    PixelFormats.Bgr32,
                    null);
            }
    
            this.colorImageBitmap.WritePixels(
                new Int32Rect(0, 0, colorFrame.Width, colorFrame.Height),
                colorData, // video data
                colorFrame.Width * colorFrame.BytesPerPixel, // stride,
                0   // offset into the array - start at 0
                );
    
            kinectVideo.Source = new FormatConvertedBitmap(colorImageBitmap, PixelFormats.Gray32Float, null, 0);
        }
    }
