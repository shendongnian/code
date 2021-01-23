    Bitmap b16bpp;
    private void GenerateDummy16bitImage()
    {
        b16bpp = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
        var rect = new Rectangle(0, 0, IMAGE_WIDTH, IMAGE_HEIGHT);
        var bitmapData = b16bpp.LockBits(rect, ImageLockMode.WriteOnly, b16bpp.PixelFormat);
        // Calculate the number of bytes required and allocate them.
        var numberOfBytes = bitmapData.Stride * IMAGE_HEIGHT;
        var bitmapBytes = new short[IMAGE_WIDTH * IMAGE_HEIGHT];
        // Fill the bitmap bytes with random data.
        var random = new Random();
        for (int x = 0; x < IMAGE_WIDTH; x++)
        {
            for (int y = 0; y < IMAGE_HEIGHT; y++)
            {
                var i = ((y * IMAGE_WIDTH) + x); // 16bpp
                // Generate the next random pixel color value.
                var value = (short)random.Next(5);
                bitmapBytes[i] = value;         // GRAY
            }
        }
        // Copy the randomized bits to the bitmap pointer.
        var ptr = bitmapData.Scan0;
        Marshal.Copy(bitmapBytes, 0, ptr, bitmapBytes.Length);//crashes here
        // Unlock the bitmap, we're all done.
        b16bpp.UnlockBits(bitmapData);
        b16bpp.Save("random.bmp", ImageFormat.Bmp);
        Debug.WriteLine("saved");
    }
