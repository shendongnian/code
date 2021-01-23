    using System.Runtime.InteropServices;
    // ..
    public void filter1()
    {
        if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
        Bitmap bmp = new Bitmap(pictureBox1.Image);
        Size s1 = bmp.Size;
        PixelFormat fmt1 = bmp.PixelFormat;
        Rectangle rect = new Rectangle(0, 0, s1.Width, s1.Height);
        BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, fmt1);
        byte bpp = 4;  // <<-------------------set to 3 for 24bbp !!
        int size1 = bmpData.Stride * bmpData.Height;
        byte[] data = new byte[size1];
        Marshal.Copy(bmpData.Scan0, data, 0, size1);
        for (int y = 0; y < s1.Height; y++)
        {
            for (int x = 0; x < s1.Width; x++)
            {
                int index = y * bmpData.Stride + x * bpp;
                data[index + 0] = (byte) (255 - data[index + 0]);  // Blue
                data[index + 1] = (byte) (255 - data[index + 1]);  // Green
                data[index + 2] = (byte) (255 - data[index + 2]);  // Red
                data[index + 3] = 255;   // Alpha, comment out for 24 bpp!
            }
        }
        Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
        bmp.UnlockBits(bmpData);
        pictureBox2.Image = bmp;
    }
    public void filter2()
    {
        if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
        Bitmap bmp1 = new Bitmap(pictureBox1.Image);
        Size s1 = bmp1.Size;
        Bitmap bmp2 = new Bitmap(s1.Width, s1.Height);
        PixelFormat fmt1 = bmp1.PixelFormat;
        Rectangle rect = new Rectangle(0, 0, s1.Width, s1.Height);
        BitmapData bmpData1 = bmp1.LockBits(rect, ImageLockMode.ReadOnly, fmt1);
        BitmapData bmpData2 = bmp2.LockBits(rect, ImageLockMode.WriteOnly, fmt1);
        byte bpp = 4;  // set to 3 for 24bbp !!
        int size1 = bmpData1.Stride * bmpData1.Height;
        byte[] data1 = new byte[size1];
        byte[] data2 = new byte[size1];
        Marshal.Copy(bmpData1.Scan0, data1, 0, size1);
        Marshal.Copy(bmpData2.Scan0, data2, 0, size1);
        int degreeOfParallelism = Environment.ProcessorCount - 1;
        var options = new ParallelOptions();
        options.MaxDegreeOfParallelism = degreeOfParallelism;
         Parallel.For(0, bmp1.Width, options, y =>
         {
            {
               for (int x = 0; x < s1.Width; x++)
               {
                     int index = y * bmpData1.Stride + x * bpp;
                     data2[index + 0] = (byte)(255 - data1[index + 0]);  // Blue
                     data2[index + 1] = (byte)(255 - data1[index + 1]);  // Green
                     data2[index + 2] = (byte)(255 - data1[index + 2]);  // Red
                     data2[index + 3] = 255;   // Alpha, comment out for 24 bpp!
               }
            }
        });
        Marshal.Copy(data2, 0, bmpData2.Scan0, data2.Length);
        bmp1.UnlockBits(bmpData1);
        bmp2.UnlockBits(bmpData2);
        pictureBox2.Image = bmp2;
    }
