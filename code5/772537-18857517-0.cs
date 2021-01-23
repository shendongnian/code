                BitmapData d = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int length = Math.Abs(d.Stride) * image.Height;
                byte[] buff = new byte[length]; 
                Marshal.Copy(d.Scan0, buff, 0, length);
                image.UnlockBits(d);
                return buff;
