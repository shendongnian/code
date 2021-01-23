    Bitmap bmp = new Bitmap(Image.FromStream(httpPostedFileBase.InputStream, true, true));
    
    // Lock the bitmap's bits.  
    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    System.Drawing.Imaging.BitmapData bmpData =
        bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            bmp.PixelFormat);
    // data = scan0 is a pointer to our memory block.
    IntPtr data = bmpData.Scan0;
    // step = stride = amount of bytes for a single line of the image
    int step = bmpData.Stride;
    // So you can try to get you Mat instance like this:
    Mat mat = new Mat(bmp.Height, bmp.Width, CvEnum.DepthType.Cv32F, 4, data, step);
    // Unlock the bits.
    bmp.UnlockBits(bmpData);
