    float fx, fy;
    int x, y;
    bD = bmpBackClouds.LockBits(
    new System.Drawing.Rectangle(0, 0, bmpBackClouds.Width, bmpBackClouds.Height),
    System.Drawing.Imaging.ImageLockMode.ReadWrite,
    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    IntPtr s0 = bD.Scan0;
    unsafe
    {
        byte* p;
        //byte* pBU = (byte*)(void*)s0;
        for (int i = 0; i < pointtocolor.Count; i++)
        {
            p = (byte*)(void*)s0;
            fx = pointtocolor[i].X * (float)currentFactor;
            fy = pointtocolor[i].Y * (float)currentFactor;
            if ((int)fx >= bmpBackClouds.Width || (int)fy >= bmpBackClouds.Height)
            {
                continue;
            }
            x = (int)fy * bD.Stride;
            y = (int)fx * 4;
            p += (x + y);
        
            p[1] = p[2] = (byte)255;
            p[0] = (byte)0;
            p[3] = (byte)255;
        }
    }
    bmpBackClouds.UnlockBits(bD);
