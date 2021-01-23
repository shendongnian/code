      /// <summary>
            /// Gets the cropped bitmap asynchronously.
            /// </summary>
            /// <param name="originalImage">The original image.</param>
            /// <param name="startPoint">The start point.</param>
            /// <param name="cropSize">Size of the corp.</param>
            /// <param name="scale">The scale.</param>
            /// <returns>The cropped image.</returns>
            public static async Task<WriteableBitmap> GetCroppedBitmapAsync(IRandomAccessStream originalImage,
                Point startPoint, Size cropSize, double scale)
            {
                if (double.IsNaN(scale) || double.IsInfinity(scale))
                {
                    scale = 1;
                }
    
                // Convert start point and size to integer.
                var startPointX = (uint)Math.Floor(startPoint.X * scale);
                var startPointY = (uint)Math.Floor(startPoint.Y * scale);
                var height = (uint)Math.Floor(cropSize.Height * scale);
                var width = (uint)Math.Floor(cropSize.Width * scale);
    
                // Create a decoder from the stream. With the decoder, we can get 
                // the properties of the image.
                var decoder = await BitmapDecoder.CreateAsync(originalImage);
    
                // The scaledSize of original image.
                var scaledWidth = (uint)Math.Floor(decoder.PixelWidth * scale);
                var scaledHeight = (uint)Math.Floor(decoder.PixelHeight * scale);
    
                // Refine the start point and the size. 
                if (startPointX + width > scaledWidth)
                {
                    startPointX = scaledWidth - width;
                }
    
                if (startPointY + height > scaledHeight)
                {
                    startPointY = scaledHeight - height;
                }
    
                // Get the cropped pixels.
                var pixels = await GetPixelData(decoder, startPointX, startPointY, width, height,
                    scaledWidth, scaledHeight);
    
                // Stream the bytes into a WriteableBitmap
                var cropBmp = new WriteableBitmap((int)width, (int)height);
                var pixStream = cropBmp.PixelBuffer.AsStream();
                pixStream.Write(pixels, 0, (int)(width * height * 4));
    
                return cropBmp;
            }
