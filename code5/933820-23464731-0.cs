    Bitmap bmp = new Bitmap(@"d:\stripe.jpg");
    //pictureBox1.Image = bmp;
    
    Stopwatch Timer = new Stopwatch();
    
    Rectangle bmpRec = new Rectangle(0, 0, bmp.Width, bmp.Height);
    BitmapData bmpData = bmp.LockBits(
        bmpRec, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    IntPtr Pointer = bmpData.Scan0;
    int DataBytes = Math.Abs(bmpData.Stride) * bmp.Height;
    byte[] rgbValues = new byte[DataBytes];
    Marshal.Copy(Pointer, rgbValues, 0, DataBytes);
    bmp.UnlockBits(bmpData);
    
    StringBuilder pix = new StringBuilder(" ");
    Timer.Start();
    for (int i = 0; i < bmpData.Width; i++)
    {
        for (int j = 0; j < bmpData.Height; j++)
        {
            // compute the proper offset into the array for these co-ords
            var pixel = rgbValues[i + j*Math.Abs(bmpData.Stride)];
            pix.Append(" ");
            pix.Append(pixel);
        }
    }
    Timer.Stop();
    
    Console.WriteLine(Timer.Elapsed);
