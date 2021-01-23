    public static void RGBtoBGR(Bitmap bmp)
    {
        BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                                       ImageLockMode.ReadWrite, bmp.PixelFormat);
        int length = Math.Abs(data.Stride) * bmp.Height;
        unsafe
        {
            byte* rgbValues = (byte*)data.Scan0.ToPointer();
            for (int i = 0; i < length; i += 3)
            {
                byte dummy = rgbValues[i];
                rgbValues[i] = rgbValues[i + 2];
                rgbValues[i + 2] = dummy;
            }
        }
        bmp.UnlockBits(data);
    }
