    BitmapData b1 = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),  
                                 System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                 System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    
    int stride = b1.Stride;
    int k;
    System.IntPtr Scan0 = b1.Scan0;
    unsafe
    {
        byte* p;
        for (k = 0; k < pointtocolor.Count; k++)
        {
            p = (byte*)(void*)Scan0;
            p += ( (int)(pointtocolor[k].Y * (float)stride * (float)currentFactor) +  
                   (int)(pointtocolor[k].X * (float)currentFactor) * 4F) );
            p[1] = p[2] = (byte)255;
            p[0] = (byte)0;
            p[3] = (byte)255;
        }
    }
    bmp.UnlockBits(b1);
