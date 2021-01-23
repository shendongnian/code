    public static byte[] ConvertToByteArray(WriteableBitmap writeableBitmap)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    writeableBitmap.SaveJpeg(ms, writeableBitmap.PixelWidth, writeableBitmap.PixelHeight, 0, 100);
    
                    return ms.ToArray();
                }
            }
