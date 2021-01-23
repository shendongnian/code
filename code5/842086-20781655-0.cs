    BitmapData bData1 = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
    byte* bData1Scan0Ptr = (byte*)bData1.Scan0.ToPointer();
    byte* nextBase = bData1Scan0Ptr + bData1.Stride;
    for (int y = 0; y < bData1.Height; ++y)
    {
        ushort* pRow = (ushort*)bData1Scan0Ptr;
        for (int x = 0; x < bData1.Width; ++x)
        {
            var red = pRow[2];
            var green = pRow[1];
            var blue = pRow[0];
            pRow += 4;
        }
        bData1Scan0Ptr = nextBase;
        nextBase += bData1.Stride;
    }
