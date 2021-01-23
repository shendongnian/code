        using System.Drawing;
        using System.Drawing.Imaging;
        using System.Runtime.InteropServices;
        static Bitmap CreateRandomBitmap(Size size)
        {
            // Create a new bitmap for the size requested.
            var bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            // Lock the entire bitmap for write-only acccess.
            var rect = new Rectangle(0, 0, size.Width, size.Height);
            var bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
            // Calculate the number of bytes required and allocate them.
            var numberOfBytes = bitmapData.Stride * size.Height;
            var bitmapBytes = new byte[numberOfBytes];
            // Fill the bitmap bytes with random data.
            var random = new Random();
            for (int x = 0; x < size.Width; x++)
            {
                for (int y = 0; y < size.Height; y++)
                {
                    // Get the index of the byte for this pixel (x/y).
                    var i = ((y * size.Width) + x) * 4; // 32bpp
                    // Generate the next random pixel color value.
                    var value = (byte)random.Next(9);
                    bitmapBytes[i] = value;         // BLUE
                    bitmapBytes[i + 1] = value;     // GREEN
                    bitmapBytes[i + 2] = value;     // RED
                    bitmapBytes[i + 3] = 0xFF;      // ALPHA
                }
            }
            // Copy the randomized bits to the bitmap pointer.
            var ptr = bitmapData.Scan0;
            Marshal.Copy(bitmapBytes, 0, ptr, numberOfBytes);
            // Unlock the bitmap, we're all done.
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }
