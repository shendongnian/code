    public static Bitmap Multiply(Bitmap bmp0, Bitmap bmp1)
    {
        int Bpp = 4;  // assuming an effective pixelformat of 32bpp
        var bmpData0 = bmp0.LockBits(
                        new Rectangle(0, 0, bmp0.Width, bmp0.Height),
                        ImageLockMode.ReadWrite, bmp0.PixelFormat);
        var bmpData1 = bmp1.LockBits(
                        new Rectangle(0, 0, bmp1.Width, bmp1.Height),
                        ImageLockMode.ReadOnly, bmp1.PixelFormat);
        int len = bmpData0.Height * bmpData0.Stride;
        byte[] data0 = new byte[len];
        byte[] data1 = new byte[len];
        Marshal.Copy(bmpData0.Scan0, data0, 0, len);
        Marshal.Copy(bmpData1.Scan0, data1, 0, len);
        for (int i = 0; i < len; i += Bpp)
        {
            //float h = (data1[i] + data1[i + 1] + data1[i + 2]) / (255 * 3f);
            float h = data1[i] / 255;          // assuming a grayscale structure overlay
            data0[i] = (byte)((data0[i] * h));
            data0[i+1] = (byte)( (data0[i+1]  * h));
            data0[i+2] = (byte)( (data0[i+2]  * h));
            if (Bpp == 4) data0[i + 3] = 255;   // shouldn't be necessary
        }
        Marshal.Copy(data0, 0, bmpData0.Scan0, len);
        bmp0.UnlockBits(bmpData0);
        bmp1.UnlockBits(bmpData1);
        return bmp0;
    }
