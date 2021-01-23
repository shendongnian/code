    private void button3_Click(object sender, EventArgs e)
    {
        // pick one of our filter methods
        ModifyHue hueChanger = new ModifyHue(MaxChannel);
        // we pull the bitmap from the image
        Bitmap bmp = (Bitmap)pictureBox1.Image;
        Size s = bmp.Size;
        PixelFormat fmt = bmp.PixelFormat;
        // we need the bit depth and we assume either 32bppArgb or 24bppRgb !
        byte bpp = (byte)(fmt == PixelFormat.Format32bppArgb ? 4 : 3);
        // lock the bits and prepare the loop
        Rectangle rect = new Rectangle(Point.Empty, s);
        BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, fmt);
        int size1 = bmpData.Stride * bmpData.Height;
        byte[] data = new byte[size1];
        System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, size1);
        // loops
        for (int y = 0; y < s.Height; y++)
        {
            for (int x = 0; x < s.Width; x++)
            {
                // calculate the index
                int index = y * bmpData.Stride + x * bpp;
                // get the color
                Color c = Color.FromArgb( bpp == 4 ?data[index + 3]: 255 , 
                                          data[index + 2], data[index + 1], data[index]);
                // process it
                c = hueChanger(c, 2); 
                // set the channels from the new color
                data[index + 0] = c.B;
                data[index + 1] = c.G;
                data[index + 2] = c.R;
                if (bpp == 4) data[index + 3] = c.A;
            }
        }
        System.Runtime.InteropServices.Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
        bmp.UnlockBits(bmpData);
       // we need to re-assign the changed bitmap
        pictureBox1.Image = (Bitmap)bmp;
    }
