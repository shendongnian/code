    public Bitmap ImageFade( Bitmap sourceBitmap, byte Transparency)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                        sourceBitmap.Width, sourceBitmap.Height),
                                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);
            byte blue = 0;
            byte green = 0;
            byte red = 0;
            byte a = 0;
            int byteOffset = 0;
            for (int offsetY = 0; offsetY <
                 sourceBitmap.Height; offsetY++)
            {
                for (int offsetX = 0; offsetX <
                     sourceBitmap.Width; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;
                    a = 0;
                    byteOffset = offsetY *
                                    sourceData.Stride +
                                    offsetX * 4;
                    blue += pixelBuffer[byteOffset];
                    green += pixelBuffer[byteOffset + 1];
                    red += pixelBuffer[byteOffset + 2];
                    a += Transparency;//pixelBuffer[byteOffset + 3];
                  
                    resultBuffer[byteOffset] = blue;
                    resultBuffer[byteOffset + 1] = green;
                    resultBuffer[byteOffset + 2] = red;
                    resultBuffer[byteOffset + 3] = a;
                }
            }
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);
            return resultBitmap;
        }
