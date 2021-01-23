    Bitmap bmp = (Bitmap) LogPictureBox.Image.Clone();
    BitmapData bmpData = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), 
                                      ImageLockMode.ReadOnly, bmp.PixelFormat);
    PixelFormat fmt = bmp.PixelFormat;
    int bpp = fmt == PixelFormat.Format24bppRgb ? 3 : 4;
    int bmpSize = bmpData.Stride * bmpData.Height * bpp;
    bmp.UnlockBits(bmpData);
    bmp.Dispose();
