    BitmapData bmd = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height),
                                        System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                        myBitmap.PixelFormat);
    
    int PixelSize = 4;
    
    unsafe
    {
        for (int y = 0; y < bmd.Height; y++)
        {
            byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);
    
            for (int x = 0; x < bmd.Width; x++)
            {
                if (!IsInArea(x, y, 200, 30, 250, 30))
                {
                    int b = row[x * PixelSize];         //Blue
                    int g = row[x * PixelSize + 1];     //Green
                    int r = row[x * PixelSize + 2];     //Red
                    int a = row[x * PixelSize + 3];     //Alpha
    
                    Color c = Color.FromArgb(a, r, g, b);
    
                    float brightness = c.GetBrightness();
                }
    
            }
        }
    }
    
    myBitmap.UnlockBits(bmd);
