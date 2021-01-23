    public static byte[] ConvertToByteArray(WriteableBitmap writeableBitmap)
    {
        using (var ms = new MemoryStream())
        {
            writeableBitmap.SaveJpeg(ms, writeableBitmap.PixelWidth, writeableBitmap.PixelHeight, 0, 100);
            return ms.ToArray();
        }
    }
