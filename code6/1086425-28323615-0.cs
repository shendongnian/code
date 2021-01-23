    public void dataAcquired()
    {
        Bitmap bmp = new Bitmap(width, height); 
        BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
        unsafe
        {
            int i = 0;
            byte* ptr = (byte*)data.Scan0;
            for( int y = 0;  y < bmp.Height;  y++ )
            {
                byte* ptr2 = ptr;
                for( int x = 0;  x < bmp.Width;  x++ )
                {
                    Rgb rgb = mapColors[data[i++]];
                    *(ptr2++) = rgb.b;
                    *(ptr2++) = rgb.g;
                    *(ptr2++) = rgb.r;
                }
                ptr += data.Stride;
            }
        }
        bmp.UnlockBits(data);
    }
