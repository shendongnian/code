        /// <summary>
        /// Clears the alpha value of all pixels matching the given colour.
        /// </summary>
        public static Bitmap MakeTransparentKeepColour(Bitmap image, Color clearColour)
        {
            Bitmap bm32 = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
            Int32 width = bm32.Width;
            Int32 height = bm32.Height;
            // Paint the original on a new 32bpp argb image, so we're sure of the byte data format.
            using (Graphics gr = Graphics.FromImage(bm32))
                gr.DrawImage(image, new Rectangle(0, 0, width, height));
            BitmapData sourceData = bm32.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, bm32.PixelFormat);
            Int32 stride = sourceData.Stride;
            // Copy the image data into a local array so we can use managed functions to manipulate it.
            Byte[] data = new Byte[stride * height];
            Marshal.Copy(sourceData.Scan0, data, 0, data.Length);
            Byte colR = clearColour.R;
            Byte colG = clearColour.G;
            Byte colB = clearColour.B;
            for (Int32 y = 0; y < height; y++)
            {
                Int32 inputOffs = y * stride;
                for (Int32 x = 0; x < width; x++)
                {
                    if (data[inputOffs + 2] == colR && data[inputOffs + 1] == colG && data[inputOffs] == colB)
                        data[inputOffs + 3] = 0;
                    inputOffs += 4;
                }
            }
            // Copy the edited image data back.
            Marshal.Copy(data, 0, sourceData.Scan0, data.Length);
            bm32.UnlockBits(sourceData);
            return bm32;
        }
