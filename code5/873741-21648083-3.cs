    public unsafe static bool AreEqual(Bitmap b1, Bitmap b2)
    {
        if (b1.Size != b2.Size)
        {
            return false;
        }
        if (b1.PixelFormat != b2.PixelFormat)
        {
            return false;
        }
        if (b1.PixelFormat != PixelFormat.Format32bppArgb)
        {
            return false;
        }
        Rectangle rect = new Rectangle(0, 0, b1.Width, b1.Height);
        BitmapData data1
            = b1.LockBits(rect, ImageLockMode.ReadOnly, b1.PixelFormat);
        BitmapData data2
            = b2.LockBits(rect, ImageLockMode.ReadOnly, b1.PixelFormat);
        int* p1 = (int*)data1.Scan0;
        int* p2 = (int*)data2.Scan0;
        int byteCount = b1.Height * data1.Stride / 4; //only Format32bppArgb 
        bool result = true;
        for (int i = 0; i < byteCount; ++i)
        {
            if (*p1++ != *p2++)
            {
                result = false;
                break;
            }
        }
        b1.UnlockBits(data1);
        b2.UnlockBits(data2);
        return result;
    }
