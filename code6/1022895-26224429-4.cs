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
    private IEnumerable<KeyValuePair<Point, Tuple<Color, Color>>> GetDifferences(Bitmap a, Bitmap b)
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
                         .Select(x =>
                                 {
                                     Point pt = new Point(x, y);
                                     int pixelIndex = (y * stride) + (x * bytesPerPixel);
                                     Color colorA = ReadPixel(rgbValuesA, pixelIndex, bytesPerPixel);
                                     Color colorB = ReadPixel(rgbValuesB, pixelIndex, bytesPerPixel);
                                     
                                     return new KeyValuePair<Point, Tuple<Color, Color>>(pt, colorA, colorB);
                                 }
    }
    private Color ReadPixel(byte[] bytes, int offset, int bytesPerPixel)
    {
        int argb = BitConverter.ToInt32(pixelBytes, offset);
        if (bytesPerPixel == 3) // no alpha
            argb |= (255 << 24);
        return Color.FromArgb(argb);
    }
    public IEnumerable<KeyValuePair<Point, Color>> GetNewColors(Bitmap _new, Bitmap old)
    {
        return GetDifferences(_new, old).Select(c => new KeyValuePair<Point, Color>(c.Key, c.Value.Item1));
    }
