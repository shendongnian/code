    public Bitmap ImageFade( Bitmap sourceBitmap, byte Transparency)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                        sourceBitmap.Width, sourceBitmap.Height),
                                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);
            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;
            double a = 0.0;
            int filterOffset = 0;
            int calcOffset = 0;
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
                    blue += (double)(pixelBuffer[byteOffset]);
                    green += (double)(pixelBuffer[byteOffset + 1]);
                    red += (double)(pixelBuffer[byteOffset + 2]);
                    a += Transparency;//(double)(pixelBuffer[byteOffset + 3]);
                  
                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }
                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }
                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }
                    if (a > 255)
                    { a = 255; }
                    else if (a < 0)
                    { a = 0; }
                    resultBuffer[byteOffset] = (byte)blue;
                    resultBuffer[byteOffset + 1] = (byte)green;
                    resultBuffer[byteOffset + 2] = (byte)red;
                    resultBuffer[byteOffset + 3] = (byte)a;
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
