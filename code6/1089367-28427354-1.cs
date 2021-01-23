    public void DoStuffWithImage(System.Drawing.Image imageIn)
    {
        // Lock the bitmap's bits.  
        Rectangle rect = new Rectangle(0, 0, imageIn.Width, imageIn.Height);
        System.Drawing.Imaging.BitmapData bmpData =
                        imageIn.LockBits(rect, System.Drawing.Imaging.ImageLockMode.Read,
                        imageIn.PixelFormat);
    
        // Access your data from here this scan0,
        // and do any pixel operation with this imagePtr.
        IntPtr imagePtr = bmpData.Scan0;
    
        // When you're done with it, unlock the bits.
        imageIn.UnlockBits(bmpData);
    }
