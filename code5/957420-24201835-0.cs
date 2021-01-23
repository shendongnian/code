    BitmapData blueData = blueBitmap.LockBits(new Rectangle(0, 0, blueBitmap.Width, blueBitmap.Height), ImageLockMode.ReadOnly, blueBitmap.PixelFormat);
    int lineBytes = blueBitmap.Width * 3;
    int numbBytes = lineBytes * blueBitmap.Height;
    byte[] blueBytes = new byte[numbBytes];
    for (int y = 0; y < blueBitmap.Height; y++) {
      Marshal.Copy(blueData.Scan0 + y * blueData.Stride, blueBytes, y * lineBytes, lineBytes);
    }
    blueBitmap.UnlockBits(blueData);
    blueBitmap.Dispose();
