    private byte[] UnlockBits(Bitmap bmp, out int stride)
    {
        BitmapData bmpData = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
        IntPtr ptr = bmpData.Scan0;
        stride = bmpData.Stride;
        int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
        byte[] ret = new byte[bytes];
        System.Runtime.InteropServices.Marshal.Copy(ptr, ret, 0, bytes);
        bmp.UnlockBits(bmpData);
        return ret;
    }
    private bool AreArraysEqual(byte[] a, byte[] b, int offset, int length)
    {
        for (int v = 0; v < length; v++)
        {
            int c = v + offset;
            if (a[c] != b[c])
            {
                return false;
            }
        }
        return true;
    }
    private IEnumerable<Point> GetDifferences(Bitmap a, Bitmap b)
    {
        if (a.PixelFormat != b.PixelFormat)
            throw new ArgumentException("Unmatched formats!");
        if (a.Size != b.Size)
            throw new ArgumentException("Unmatched length!");
        int stride;
        byte[] rgbValuesA = UnlockBits(a, out stride);
        byte[] rgbValuesB = UnlockBits(b, out stride);
        if (rgbValuesA.Length != rgbValuesB.Length)
            throw new ArgumentException("Unmatched array lengths (unexpected error)!");
        int bytesPerPixel = Image.GetPixelFormatSize(a.PixelFormat) / 8;
        return Enumerable.Range(0, a.Height).SelectMany(y =>
               Enumerable.Range(0, a.Width)
                         .Where(x => !AreArraysEqual(rgbValuesA,
                                                     rgbValuesB,
                                                     (y * stride) + (x * bytesPerPixel),
                                                     bytesPerPixel))
                         .Select(x => new Point(x, y)));
    }
    public IEnumerable<KeyValuePair<Point, Color>> GetNewColors(Bitmap _new, Bitmap old)
    {
        return GetDifferences(_new, old).Select(c => new KeyValuePair<Point, Color>(c, _new.GetPixel(c)));
    }
