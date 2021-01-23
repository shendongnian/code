    compare(originalPathFile + files[0].ToString() + ".png", originalPathFile + files[count2].ToString() + ".png")
    private bool compare(String bmp1Path, String bmp2Path)
    {
        bool equals = true;
        Rectangle rect = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
    using(Bitmap im1 = new Bitmap(bmp1Path)
    {
    using(Bitmap im2 = new Bitmap(bmp2Path)
    {
    BitmapData bmpData1 = bmp1.LockBits(rect, ImageLockMode.ReadOnly, bmp1.PixelFormat);
    BitmapData bmpData2 = bmp2.LockBits(rect, ImageLockMode.ReadOnly, bmp2.PixelFormat);
    unsafe
    {
        byte* ptr1 = (byte*)bmpData1.Scan0.ToPointer();
        byte* ptr2 = (byte*)bmpData2.Scan0.ToPointer();
        int width = rect.Width * 3; // for 24bpp pixel data
        for (int y = 0; equals && y < rect.Height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (*ptr1 != *ptr2)
                {
                    equals = false;
                    break;
                }
                ptr1++;
                ptr2++;
            }
            ptr1 += bmpData1.Stride - width;
            ptr2 += bmpData2.Stride - width;
        }
    }
    bmp1.UnlockBits(bmpData1);
    bmp2.UnlockBits(bmpData2);
    }
    }
    return equals;
}
