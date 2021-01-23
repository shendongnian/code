    public IEnumerable<Point> GetDifferences(Bitmap a, Bitmap b)
    {
        BitmapData bmpDataA = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.ReadOnly, a.PixelFormat);
        BitmapData bmpDataB = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.ReadOnly, b.PixelFormat);
        IntPtr ptrA = bmpDataA.Scan0;
        IntPtr ptrB = bmpDataB.Scan0;
        // Declare an array to hold the bytes of the bitmap. 
        int bytesA = Math.Abs(bmpDataA.Stride) * a.Height;
        byte[] rgbValuesA = new byte[bytesA];
        byte[] rgbValuesB = new byte[bytesA]; // assumption they're the same length
        System.Runtime.InteropServices.Marshal.Copy(ptrA, rgbValuesA, 0, bytes);
        System.Runtime.InteropServices.Marshal.Copy(ptrB, rgbValuesB, 0, bytes);
        int bytesPerPixel = Image.GetPixelFormatSize(bmpDataA.PixelFormat) / 8;
        // assume they're the same format
        int strideInBytes = bmpDataA.Stride;
        a.UnlockBits(bmpDataA);
        b.UnlockBits(bmpDataB);
        return Enumerable.Range(0, a.Height).SelectMany(y =>
               Enumerable.Range(0, a.Width)
                         .Select(x => 
                         {
                             int byteIndex = (y * strideInBytes) + (x * bytesPerPixel);
                             bool match = true;
                             for (int p = 0; p < bytesPerPixel; p++)
                             {
                                 int cByte = p + byteIndex;
                                 if (rgbValuesA[cByte] != rgbValuesB[cByte])
                                 {
                                     match = false;
                                     break;
                                 }
                             }
                             if (match)
                                 return (Point?)null;
                             else
                                 return new Point(x, y);
                         })
                         .Where(c => c.HasValue)
                         .Select(c => c.Value));
    }
