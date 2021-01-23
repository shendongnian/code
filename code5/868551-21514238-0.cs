    public static Bitmap ByteArrayToBitmap(byte[] byteArray)
    {
        int width = 2144;
        int height = 3;
        using(Bitmap bitmapImage = new Bitmap(width, height, PixelFormat.Format32bppPArgb))
        {
            BitmapData bmpData = bitmapImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
            IntPtr ptr = bmpData.Scan0;
            Marshal.Copy(byteArray, 0, ptr, byteArray.Length);
            bitmapImage.UnlockBits(bmpData);
            return bitmapImage;
        }
    }
