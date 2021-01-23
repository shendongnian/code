    BitmapData b1 = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),  
                                 System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                 System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    
    int stride = b1.Stride;
    int k, x, y;
    System.IntPtr Scan0 = b1.Scan0;
    unsafe
    {
        byte* p;
        for (k = 0; k < pointtocolor.Count; k++)
        {
            //set pointer to the beggining
            p = (byte*)(void*)Scan0;
            //Add offset where the point is. The formula: position = Y * stride + X * 4 
            x = (int)(pointtocolor[k].Y * (float)stride * (float)currentFactor);
            y = (int)(pointtocolor[k].X * (float)currentFactor) * 4F)
            
            p += ( x + y );
            //set yellow color
            p[1] = p[2] = (byte)255;
            p[0] = (byte)0;
            p[3] = (byte)255;
        }
    }
    bmp.UnlockBits(b1);
