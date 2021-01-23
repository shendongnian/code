    byte[] data = new byte[320 * 200 * 1];
    
    Bitmap bmp1 = new Bitmap(320, 200, 
           System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
    Bitmap bmp2 = new Bitmap(320, 200, 
           System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
    
    var bdata = bmp1.LockBits(new Rectangle(new Point(0, 0), bmp1.Size), 
                     ImageLockMode.WriteOnly, bmp1.PixelFormat);
    try
    {
    	Marshal.Copy(data, 0, bdata.Scan0, data.Length);
    }
    finally
    {
    	bmp1.UnlockBits(bdata);
    }
    
    // Do your modifications
    
    bdata = bmp2.LockBits(new Rectangle(new Point(0, 0), bmp2.Size), 
                 ImageLockMode.WriteOnly, bmp2.PixelFormat);
    try
    {
    	Marshal.Copy(data, 0, bdata.Scan0, data.Length);
    }
    finally
    {
    	bmp2.UnlockBits(bdata);
    }
