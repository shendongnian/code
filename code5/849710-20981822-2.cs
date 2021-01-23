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
            
            for(int i = 0; i < numberOfBytes; i++)
            {
                bitmapBytes[i] = (byte)random.Next(9);
            }
            // Copy the randomized bits to the bitmap pointer.
            var ptr = bitmapData.Scan0;
            Marshal.Copy(bitmapBytes, 0, ptr, numberOfBytes);
            // Unlock the bitmap, we're all done.
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }
