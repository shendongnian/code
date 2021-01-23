    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace ImageManipulation
    {
        class FastImage : IDisposable
        {
            private Bitmap _buffer;
            private byte[] _rawData;
            private GCHandle _rawHandle;
            private int _formatSize;
            private int _width;
            private int _height;
    
            public int Width
            {
                get { return _width; }
            }
    
            public int Height
            {
                get { return _height; }
            }
    
            public byte[] GetRawData()
            {
                return _rawData;
            }
    
            public byte this[int index]
            {
                get { return _rawData[index]; }
                set { _rawData[index] = value; }
            }
    
            public Color this[int x, int y]
            {
                get
                {
                    return GetPixel(x, y);
                }
                set
                {
                    SetPixel(x, y, value);
                }
            }
    
            public Color GetPixel(int x, int y)
            {
                var offset = y*_width*_formatSize;
                offset += x*_formatSize;
                return Color.FromArgb(_rawData[offset + 3], _rawData[offset + 2], _rawData[offset + 1], _rawData[offset]);
            }
    
            public void SetPixel(int x, int y, Color value)
            {
                var offset = y*_width*_formatSize;
                offset += x*_formatSize;
    
                _rawData[offset] = value.B;
                _rawData[offset + 1] = value.G;
                _rawData[offset + 2] = value.R;
                _rawData[offset + 3] = value.A;
    
            }
    
            private FastImage() { }
    
            public static FastImage Create(Image source)
            {
                var image = new FastImage();
    
                var bmpSource = new Bitmap(source);
                var bmpData = bmpSource.LockBits(new Rectangle(0, 0, source.Width, source.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bmpSource.PixelFormat);
    
                image._width = source.Width;
                image._height = source.Height;
    
                image._formatSize = 4;
                var stride = bmpSource.Width * image._formatSize;
                image._rawData = new byte[stride * bmpSource.Height];
                image._rawHandle = GCHandle.Alloc(image._rawData, GCHandleType.Pinned);
                var pointer = Marshal.UnsafeAddrOfPinnedArrayElement(image._rawData, 0);
                image._buffer = new Bitmap(bmpSource.Width, bmpSource.Height, stride, PixelFormat.Format32bppArgb /*bmpSource.PixelFormat*/, pointer);
                bmpSource.UnlockBits(bmpData);
    
                var graphics = Graphics.FromImage(image._buffer);
    
                graphics.DrawImageUnscaledAndClipped(bmpSource, new Rectangle(0, 0, source.Width, source.Height));
                graphics.Dispose();
    
                return image;
            }
    
            public void Dispose()
            {
                _rawHandle.Free();
                _buffer.Dispose();
            }
    
            public void Save(Stream stream)
            {
                _buffer.Save(stream, ImageFormat.Bmp);
            }
    
            public Bitmap ToBitmap()
            {
                return (Bitmap)_buffer.Clone();
            }
        }
    }
