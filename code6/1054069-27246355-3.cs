        public struct Pixel : IEquatable<Pixel>
        {
            // ReSharper disable UnassignedField.Compiler
            public byte Blue;
            public byte Green;
            public byte Red;
            public bool Equals(Pixel other)
            {
                return Red == other.Red && Green == other.Green && Blue == other.Blue;
            }
        }
        public static Color[,] GetPixels(Bitmap two)
        {
            return ProcessBitmap(two, pixel => Color.FromArgb(pixel.Red, pixel.Green, pixel.Blue));
        }
        public static float[,] GetBrightness(Bitmap two)
        {
            return ProcessBitmap(two, pixel => Color.FromArgb(pixel.Red, pixel.Green, pixel.Blue).GetBrightness());
        }
        public static unsafe T[,] ProcessBitmap<T>(Bitmap bitmap, Func<Pixel, T> func)
        {
            var lockBits = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly,
                                       bitmap.PixelFormat);
            int padding = lockBits.Stride - (bitmap.Width * sizeof(Pixel));
            int width = bitmap.Width;
            int height = bitmap.Height;
            var result = new T[height, width];
            var ptr = (byte*)lockBits.Scan0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var pixel = (Pixel*)ptr;
                    result[i, j] = func(*pixel);
                    ptr += sizeof(Pixel);
                }
                ptr += padding;
            }
            bitmap.UnlockBits(lockBits);
            return result;
        }
        public static Bitmap CreateBitmap(Color[,] colors)
        {
            const int bytesPerPixel = 4, stride = 8;
            int width = colors.GetLength(0);
            int height = colors.GetLength(1);
            byte[] bytes = new byte[width*height*bytesPerPixel];
            int n = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bytes[n++] = colors[i, j].R;
                    bytes[n++] = colors[i, j].G;
                    bytes[n++] = colors[i, j].B;
                    bytes[n++] = colors[i, j].A;
                }
            }
            return CreateBitmap(bytes, width, height, stride, PixelFormat.Format32bppArgb);
        }
        public static Bitmap CreateBitmap(byte[] data, int width, int height, int stride, PixelFormat format)
        {
            var arrayHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            var bmp = new Bitmap(width, height, stride, format, arrayHandle.AddrOfPinnedObject());
            arrayHandle.Free();
            return bmp;
        }
    }
