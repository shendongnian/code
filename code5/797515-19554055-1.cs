        var downsizeImage = ImageTools.ConvertToBitonal(scaledBmp, 500);
                        downsizeImage.Save(string.Format(@"C:\Temp\{0}Downsized.png", betSlipImage.BetSlipID), ImageFormat.Png);
                        var ms = new MemoryStream();
                        downsizeImage.Save(ms, ImageFormat.Png);
    
       public static Bitmap ConvertToBitonal(Bitmap original, int threshold)
            {
                Bitmap source;
    
                // If original bitmap is not already in 32 BPP, ARGB format, then convert
                if (original.PixelFormat != PixelFormat.Format32bppArgb)
                {
                    source = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb);
                    source.SetResolution(original.HorizontalResolution, original.VerticalResolution);
    
                    using (var g = Graphics.FromImage(source))
                    {
                        g.DrawImageUnscaled(original, 0, 0);
                    }
                }
                else
                {
                    source = original;
                }
    
                // Lock source bitmap in memory
                var sourceData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
    
                // Copy image data to binary array
                var imageSize = sourceData.Stride * sourceData.Height;
                var sourceBuffer = new byte[imageSize];
                Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, imageSize);
    
                // Unlock source bitmap
                source.UnlockBits(sourceData);
    
                // Create destination bitmap
                var destination = new Bitmap(source.Width, source.Height, PixelFormat.Format1bppIndexed);
                destination.SetResolution(original.HorizontalResolution, original.VerticalResolution);
    
                // Lock destination bitmap in memory
                var destinationData = destination.LockBits(new Rectangle(0, 0, destination.Width, destination.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
    
                // Create destination buffer
                imageSize = destinationData.Stride * destinationData.Height;
                var destinationBuffer = new byte[imageSize];
    
                var sourceIndex = 0;
                var destinationIndex = 0;
                var pixelTotal = 0;
                byte destinationValue = 0;
                var pixelValue = 128;
                var height = source.Height;
                var width = source.Width;
    
                // Iterate lines
                for (var y = 0; y < height; y++)
                {
                    sourceIndex = y * sourceData.Stride;
                    destinationIndex = y * destinationData.Stride;
                    destinationValue = 0;
                    pixelValue = 128;
    
                    // Iterate pixels
                    for (var x = 0; x < width; x++)
                    {
                        // Compute pixel brightness (i.e. total of Red, Green, and Blue values) - Thanks murx
                        //                           B                             G                              R
                        pixelTotal = sourceBuffer[sourceIndex] + sourceBuffer[sourceIndex + 1] + sourceBuffer[sourceIndex + 2];
                        if (pixelTotal > threshold)
                        {
                            destinationValue += (byte)pixelValue;
                        }
                        if (pixelValue == 1)
                        {
                            destinationBuffer[destinationIndex] = destinationValue;
                            destinationIndex++;
                            destinationValue = 0;
                            pixelValue = 128;
                        }
                        else
                        {
                            pixelValue >>= 1;
                        }
                        sourceIndex += 4;
                    }
    
                    if (pixelValue != 128)
                    {
                        destinationBuffer[destinationIndex] = destinationValue;
                    }
                }
    
                // Copy binary image data to destination bitmap
                Marshal.Copy(destinationBuffer, 0, destinationData.Scan0, imageSize);
    
                // Unlock destination bitmap
                destination.UnlockBits(destinationData);
    
                // Dispose of source if not originally supplied bitmap
                if (source != original)
                {
                    source.Dispose();
                }
    
                // Return
                return destination;
            }
