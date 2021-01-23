     public static byte[] ConvertToBytes(WriteableBitmap bitmapImage)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Extensions.SaveJpeg(bitmapImage, ms,
                        bitmapImage.PixelWidth, bitmapImage.PixelHeight, 0, 100);
    
                    return ms.ToArray();
                }
            }
