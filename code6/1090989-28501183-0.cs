    public static Bitmap MakeTransparent(Bitmap bmp, Color col, int delta)
    {
        // we expect a 32bpp bitmap!
        var bmpData = bmp.LockBits(
                                new Rectangle(0, 0, bmp.Width, bmp.Height),
                                ImageLockMode.ReadWrite, bmp.PixelFormat);
        long len = bmpData.Height * bmpData.Stride;
        byte[] data = new byte[len];
        Marshal.Copy(bmpData.Scan0, data, 0, data.Length);
        for (int i = 0; i < len; i += 4)
        {
            int dist = Math.Abs(data[i + 0] - col.B);
            dist += Math.Abs(data[i + 0] - col.G);
            dist += Math.Abs(data[i + 0] - col.R);
            if (dist <= delta) data[i + 3] = 0;
        }
        Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
        bmp.UnlockBits(bmpData);
        return bmp;
    }
