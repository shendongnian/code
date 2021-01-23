    Bitmap bmp = new Bitmap("SomeImage");
    
    // Lock the bitmap's bits.  
    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
    
    // Get the address of the first line.
    IntPtr ptr = bmpData.Scan0;
    
    // Declare an array to hold the bytes of the bitmap.
    int bytes = bmpData.Stride * bmp.Height;
    byte[] rgbValues = new byte[bytes];
    byte[] r = new byte[bytes / 3];
    byte[] g = new byte[bytes / 3];
    byte[] b = new byte[bytes / 3];
    
    // Copy the RGB values into the array.
    Marshal.Copy(ptr, rgbValues, 0, bytes);
    
    int count = 0;
    int stride = bmpData.Stride;
    
    for (int column = 0; column < bmpData.Height; column++)
    {
        for (int row = 0; row < bmpData.Width; row++)
        {
            b[count] = (byte)(rgbValues[(column * stride) + (row * 3)]) 
            g[count] = (byte)(rgbValues[(column * stride) + (row * 3) + 1]);
            r[count++] = (byte)(rgbValues[(column * stride) + (row * 3) + 2]);
        }
    }
