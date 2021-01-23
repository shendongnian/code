    public BitmapImage ConvertTexture2DToBitmapImage(Texture2D texture2D)
            {
                byte[] textureData = new byte[4 * texture2D.Width * texture2D.Height];
                texture2D.GetData(textureData);
                ExtendedImage extendedImage = new ExtendedImage();
                extendedImage.SetPixels(texture2D.Width, texture2D.Height, textureData);
                JpegEncoder encoder = new JpegEncoder();
                using (Stream picStream = new MemoryStream())
                {
                    encoder.Encode(extendedImage, picStream);
                    picStream.Position = 0;
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(picStream);
                    return bitmapImage;
                }
            }
