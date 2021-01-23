    private bool ImageComparison(Bitmap Image1, Bitmap Image2, Rectangle Rect, double tol)
        {
            int x, y, p, stride1, stride2;
            int bytes, bytesPerPixel;
            byte[] rgbValues1;
            byte[] rgbValues2;
            double Dr, Dg, Db, color_distance;
            IntPtr ptr;
            Rectangle rect;
            BitmapData bitmap_Data;
            
            if ( (Image1.Width != Image2.Width) || (Image1.Height != Image2.Height) )
            {
                MessageBox.Show("Images are different Size");
                return false;
            }
            if (Rect.X < 0 || Rect.Y < 0 || ((Rect.X + Rect.Width) > Image1.Width) || ((Rect.Y + Rect.Height) > Image1.Height))
            {
                MessageBox.Show("Hello!! your region is way off!!!.. major bug!");
                return false;
            }
            rect = new Rectangle(0, 0, Image1.Width, Image1.Height);
            
            //Lock bitmap to copy its color information fast
            bitmap_Data = Image1.LockBits(rect, ImageLockMode.ReadWrite, Image1.PixelFormat);
            ptr = bitmap_Data.Scan0;
            stride1 = bitmap_Data.Stride;
            bytes = bitmap_Data.Stride * Image1.Height;
            rgbValues1 = new byte[bytes];
            //copy color information to rgbValues array
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues1, 0, bytes);
            //we are done copying so unlock bitmap. We dont need it anymore
            Image1.UnlockBits(bitmap_Data);
            rect = new Rectangle(0, 0, Image2.Width, Image2.Height);
            //Lock bitmap to copy its color information fast
            bitmap_Data = Image2.LockBits(rect, ImageLockMode.ReadWrite, Image2.PixelFormat);
            ptr = bitmap_Data.Scan0;
            stride2 = bitmap_Data.Stride;
            bytes = bitmap_Data.Stride * Image2.Height;
            rgbValues2 = new byte[bytes];
            //copy color information to rgbValues array
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues2, 0, bytes);
            //we are done copying so unlock bitmap. We dont need it anymore
            Image2.UnlockBits(bitmap_Data);
            if (stride1 != stride2) //different pixel format
            {
                MessageBox.Show("Different pixel format");
                return false;
            }
            
            bytesPerPixel = Image.GetPixelFormatSize(Image1.PixelFormat) / 8;
            //scan images pixel per pixel
            for (y = 0; y < Image1.Height; y++)
            {
                for (x = 0; x < Image1.Width; x++)
                {
                    p = y * stride1 + x * bytesPerPixel;
                    Dr = (double)(rgbValues1[p + 2] - rgbValues2[p + 2]);
                    Dg = (double)(rgbValues1[p + 1] - rgbValues2[p + 1]);
                    Db = (double)(rgbValues1[p] - rgbValues2[p]);
                    color_distance = Math.Sqrt(Dr * Dr + Dg * Dg + Db * Db);
                    if (color_distance > tol)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
