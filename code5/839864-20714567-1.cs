        unsafe public static Bitmap LockBits(Bitmap bmp)
        {
            //int tolerancenumeric = 0;
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            byte* ptr = (byte*)bmpData.Scan0;
            int numBytes = bmpData.Stride * bmp.Height+1;
            for (int counter = 0; counter < numBytes; counter += 6)
                *(ptr+counter) = (byte)tolerancenumeric;
            bmp.UnlockBits(bmpData);
            return bmp;
        }
