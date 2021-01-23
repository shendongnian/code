    protected override unsafe void ProcessFilter(UnmanagedImage image, Rectangle rect)
        {
            int pixelSize = Bitmap.GetPixelFormatSize(image.PixelFormat)/8;
            int startX = rect.Left;
            int startY = rect.Top;
            int stopX = startX + rect.Width;
            int stopY = startY + rect.Height;
            int offset = image.Stride - rect.Width*pixelSize;
            var rgb = new RGB();
            var hsl = new HSL();
            // do the job
            byte* ptr = (byte*) image.ImageData.ToPointer();
            // allign pointer to the first pixel to process
            ptr += (startY*image.Stride + startX*pixelSize);
            
            // for each row
            for (int y = startY; y < stopY; y++)
            {
                // for each pixel
                for (int x = startX; x < stopX; x++, ptr += pixelSize)
                {
                    rgb.Red = ptr[RGB.R];
                    rgb.Green = ptr[RGB.G];
                    rgb.Blue = ptr[RGB.B];
                    
                    // convert to HSL
                    HSL.FromRGB(rgb, hsl);
                    
                    // modify hsl values
                    hsl.Hue = hue;
                    hsl.Saturation = saturation;
                    hsl.Luminance = Math.Min(0.97f, hsl.Luminance * (120 * luminance / 65));
                    
                    // convert back to RGB
                    HSL.ToRGB(hsl, rgb);
                    ptr[RGB.R] = (byte)rgb.Red;
                    ptr[RGB.G] = (byte)rgb.Green;
                    ptr[RGB.B] = (byte)rgb.Blue;
                }
                ptr += offset;
            }
        }
