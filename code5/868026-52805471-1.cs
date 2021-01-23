    public class BitmapContainer
    {
        public PixelFormat Format { get; }
        public int Width { get; }
        public int Height { get; }
        public IntPtr Buffer { get; }
        public int Stride { get; set; }
        public BitmapContainer(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException(nameof(bitmap));
            Format = bitmap.PixelFormat;
            Width = bitmap.Width;
            Height = bitmap.Height;
            var bufferAndStride = bitmap.ToBufferAndStride();
            Buffer = bufferAndStride.Item1;
            Stride = bufferAndStride.Item2;
        }
        public Bitmap ToBitmap()
        {
            return new Bitmap(Width, Height, Stride, Format, Buffer);
        }
    }
