        public static Bitmap MakeSpecialTransparent(Bitmap bmp)
        {
            // we expect a 32bpp bitmap!
            var bmpData = bmp.LockBits(
                                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                                    ImageLockMode.ReadWrite, bmp.PixelFormat);
            long len = bmpData.Height * bmpData.Stride;
            byte[] data = new byte[len];
            Marshal.Copy(bmpData.Scan0, data, 0, data.Length);
            for (int i = 0; i < len; i += 4)
            {
                if (data[i] == 0  && data[i+1] == 0  && data[i+2] == 0  )
                {
                    data[i] = 0; data[i + 1] = 0; data[i + 2] = 0; data[i + 3] = 0;
                }
                else
                if (data[i] == 255  && data[i+1] == 255  && data[i+2] == 255  )
                {
                    data[i] = 0; data[i + 1] = 0; data[i + 2] = 255; data[i + 3] = 0;
                }
            }
            Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
            bmp.UnlockBits(bmpData);
            return bmp;
        }
