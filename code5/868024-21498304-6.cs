    void Test()
    {
        string inputFile = @"e:\temp\a.jpg";
        string outputFile = @"e:\temp\b.jpg";
        Bitmap bmp = Bitmap.FromFile(inputFile) as Bitmap;
        var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        var data = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
        var depth = Bitmap.GetPixelFormatSize(data.PixelFormat) / 8; //bytes per pixel
        var buffer = new byte[data.Width * data.Height * depth];
        //copy pixels to buffer
        Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
        Parallel.Invoke(
            () => {
                //upper-left
                Process(buffer, 0, 0, data.Width / 2, data.Height / 2, data.Width, depth);
            },
            () => {
                //lower-right
                Process(buffer, data.Width / 2, data.Height / 2, data.Width, data.Height, data.Width, depth);
            }
        );
        //Copy the buffer back to image
        Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);
        bmp.UnlockBits(data);
        bmp.Save(outputFile, ImageFormat.Jpeg);
    }
    void Process(byte[] buffer, int x, int y, int endx, int endy, int width, int depth)
    {
        for (int i = x; i < endx; i++)
        {
            for (int j = y; j < endy; j++)
            {
                var offset = ((j * width) + i) * depth;
                // Dummy work    
                // To grayscale (0.2126 R + 0.7152 G + 0.0722 B)
                var b = 0.2126 * buffer[offset + 0] + 0.7152 * buffer[offset + 1] + 0.0722 * buffer[offset + 2];
                buffer[offset + 0] = buffer[offset + 1] = buffer[offset + 2] = (byte)b;
            }
        }
    }
