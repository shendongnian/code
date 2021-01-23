    //Here create the Bitmap to the know height, width and format
    Bitmap bmp = new Bitmap(5, 7, PixelFormat.Format1bppIndexed);
    //Create a BitmapData and Lock all pixels to be written 
    BitmapData bmpData = bmp.LockBits(
    new Rectangle(0, 0, bmp.Width, bmp.Height),
    ImageLockMode.WriteOnly, bmp.PixelFormat);
    //Copy the data from the byte array into BitmapData.Scan0
    byte[] data = new byte[bmpData.Stride * bmpData.Height];
    for (int i = 0; i < data.Length; i++)
    {
        data[i] = 0xff;
    }
    Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
    //Unlock the pixels
    bmp.UnlockBits(bmpData);
