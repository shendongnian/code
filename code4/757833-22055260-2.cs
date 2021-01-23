        public static byte[] ConvertToBytes(BitmapImage bitmapImage)
        {
            using (var ms = new MemoryStream())
            {
                var btmMap = new WriteableBitmap
                    (bitmapImage.PixelWidth, bitmapImage.PixelHeight);
                // write an image into the stream
                btmMap.SaveJpeg(ms, bitmapImage.PixelWidth, bitmapImage.PixelHeight, 0, 100);
                return ms.ToArray();
            }
        }
