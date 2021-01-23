    public static Tuple<IntPtr, int> ToBufferAndStride(this Bitmap bitmap)
    {
        BitmapData bitmapData = null;
        try
        {
            bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), 
                ImageLockMode.ReadOnly, bitmap.PixelFormat);
            return new Tuple<IntPtr, int>(bitmapData.Scan0, bitmapData.Stride);
        }
        finally
        {
            if (bitmapData != null)
                bitmap.UnlockBits(bitmapData);
        }
    }
