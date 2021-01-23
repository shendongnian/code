    static void Main(string[] args)
    {
        Bitmap haystack = (Bitmap)Image.FromFile(@"c:\temp\haystack.bmp");
        Bitmap needle = (Bitmap)Image.FromFile(@"c:\temp\needle.bmp");
        Point location;
        if (FindBitmap(haystack, needle, out location) == false)
        {
            Console.WriteLine("Didn't find it");
        }
        else
        {
            using (Graphics g = Graphics.FromImage(haystack))
            {
                Brush b = new SolidBrush(Color.Red);
                Pen pen = new Pen(b, 2);
                g.DrawRectangle(pen, new Rectangle(location, new Size(needle.Width, needle.Height)));
            }
            haystack.Save(@"c:\temp\found.bmp");
            Console.WriteLine("Found it @ {0}, {1}", location.X, location.Y);
        }
        Console.ReadKey();
    }
    public class LockedBitmap : IDisposable
    {
        private BitmapData _data = null;
        private Bitmap _sourceBitmap = null;
        private byte[] _pixelData = null;
        public readonly int BytesPerPixel, WidthInBytes, Height, Width, ScanWidth;
        public LockedBitmap(Bitmap bitmap)
        {
            _sourceBitmap = bitmap;
            _data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            BytesPerPixel = Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            ScanWidth = _data.Stride;
            int byteCount = _data.Stride * bitmap.Height;
            _pixelData = new byte[byteCount];
            Marshal.Copy(_data.Scan0, _pixelData, 0, byteCount);
            WidthInBytes = bitmap.Width * BytesPerPixel;
            Height = bitmap.Height;
            Width = bitmap.Width;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetPixel(int x, int y, out int r, out int g, out int b)
        {
            int realY = y * ScanWidth;
            int realX = x * BytesPerPixel;
            b = (int)_pixelData[realY + realX];
            g = (int)_pixelData[realY + realX + 1];
            r = (int)_pixelData[realY + realX + 2];
        }
        public void Dispose()
        {
            Dispose(true);
 	        GC.SuppressFinalize(this);               
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
                
            if (_sourceBitmap != null && _data != null) 
                _sourceBitmap.UnlockBits(_data);                
        }
    }
    private static bool FindBitmap(Bitmap haystack, Bitmap needle, out Point location)
    {
        using (LockedBitmap haystackToSearch = new LockedBitmap(haystack))
        using (LockedBitmap needleToSearch = new LockedBitmap(needle))
        {
            for (int outerY = 0; outerY <= (haystackToSearch.Height - needleToSearch.Height); outerY++)
            {
                for (int outerX = 0; outerX <= (haystackToSearch.Width - needleToSearch.Width); outerX++)
                {
                    bool isMatched = true;
                    for (int innerY = 0; innerY < needleToSearch.Height; innerY++)
                    {
                        for (int innerX = 0; innerX < needleToSearch.Width; innerX++)
                        {
                            int needleR, needleG, needleB;
                            int haystackR, haystackG, haystackB;
                            haystackToSearch.GetPixel(outerX + innerX, outerY + innerY, out haystackR, out haystackG, out haystackB);
                            needleToSearch.GetPixel(innerX, innerY, out needleR, out needleG, out needleB);
                            isMatched = isMatched && needleR == haystackR && haystackG == needleG && haystackB == needleB;
                            if (!isMatched)
                                break;
                        }
                        if (!isMatched)
                            break;
                    }
                    if (isMatched)
                    {
                        location = new Point(outerX, outerY);
                        return true;
                    }
                }
            }
        }
        location = new Point();
        return false;
    }
