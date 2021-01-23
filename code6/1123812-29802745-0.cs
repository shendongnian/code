    int pixelSize = 3;
    int bytesCount = imgHeight * imgWidth * pixelSize;
    byte[] byteArray= new byte[bytesCount];
    BitmapData bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, imgWidth, imgHeight), ImageLockMode.ReadOnly, bitmap.PixelFormat);
    Marshal.Copy(bitmapData.Scan0, byteArray, 0, bytesCount);
    
