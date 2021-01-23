    public Image byteArrayToImage(byte[] byteArrayIn)
    {
        int size = (int)Math.Sqrt(byteArrayIn.Length); // Some bytes will not be used as we round down here
        Bitmap bitmap = new Bitmap(size, size, PixelFormat.Format8bppIndexed);
        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
        try
        {
            for (int rowIndex = 0; rowIndex < bitmapData.Height; ++rowIndex)
                Marshal.Copy(byteArrayIn, rowIndex * bitmap.Width, bitmapData.Scan0 + rowIndex * bitmapData.Stride, bitmap.Width);
        }
        finally
        {
            bitmap.UnlockBits(bitmapData);
        }
        return bitmap;
    }
