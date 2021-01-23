    private void Form1_Load(object sender, EventArgs e)
    {
        Color targetColor = Color.FromArgb(255, 48, 48, 216);
        pictureBox6.Image = MakeMonoChrome ((Bitmap)pictureBox1.Image, targetColor);
        pictureBox2.Image = 
                    mix2Bitmaps((Bitmap)pictureBox1.Image, (Bitmap)pictureBox6.Image, 20);
        pictureBox3.Image = 
                    mix2Bitmaps((Bitmap)pictureBox1.Image, (Bitmap)pictureBox6.Image, 40);
        pictureBox4.Image = 
                    mix2Bitmaps((Bitmap)pictureBox1.Image, (Bitmap)pictureBox6.Image, 60);
        pictureBox5.Image = 
                    mix2Bitmaps((Bitmap)pictureBox1.Image, (Bitmap)pictureBox6.Image, 80);
    }
    Bitmap mix2Bitmaps(Bitmap bmp0, Bitmap bmp1, int percent)
    {
        Bitmap bmp2 = new Bitmap(bmp0.Width, bmp0.Height, PixelFormat.Format32bppArgb);
        int Bpp = 4;  // assuming an effective pixelformat of 32bpp
        var bmpData0 = bmp0.LockBits( new Rectangle(0, 0, bmp0.Width, bmp0.Height),
                                      ImageLockMode.ReadOnly, bmp0.PixelFormat);
        var bmpData1 = bmp1.LockBits( new Rectangle(0, 0, bmp1.Width, bmp1.Height),
                                      ImageLockMode.ReadOnly, bmp1.PixelFormat);
        var bmpData2 = bmp2.LockBits( new Rectangle(0, 0, bmp2.Width, bmp2.Height),
                                      ImageLockMode.ReadWrite, bmp2.PixelFormat);
        int len = bmpData0.Height * bmpData0.Stride;
        byte[] data0 = new byte[len];
        byte[] data1 = new byte[len];
        byte[] data2 = new byte[len];
        Marshal.Copy(bmpData0.Scan0, data0, 0, len);
        Marshal.Copy(bmpData1.Scan0, data1, 0, len);
        Marshal.Copy(bmpData2.Scan0, data2, 0, len);
        float pctD = (100f - percent) / 100f;
        float pct  =  percent / 100f;
        for (int i = 0; i < len; i += Bpp)
        {
            data2[i + 0] = (byte)(data0[i + 0] * pctD + data1[i + 0] * pct);
            data2[i + 1] = (byte)(data0[i + 1] * pctD + data1[i + 1] * pct);
            data2[i + 2] = (byte)(data0[i + 2] * pctD + data1[i + 2] * pct);
            if (Bpp == 4) data2[i + 3] = 255;   
        }
        Marshal.Copy(data2, 0, bmpData2.Scan0, len);
        bmp0.UnlockBits(bmpData0);
        bmp1.UnlockBits(bmpData1);
        bmp2.UnlockBits(bmpData2);
        return bmp2;
    }
    public static Bitmap MakeMonoChrome(Bitmap bmp0, Color tCol)
    {
        Bitmap bmp1 = new Bitmap(bmp0.Width, bmp0.Height);
        using (Graphics g = Graphics.FromImage(bmp1) )
        {
          float tr = tCol.R / 255f;
          float tg = tCol.G / 255f;
          float tb = tCol.B / 255f;
          ColorMatrix colorMatrix = new ColorMatrix(  new float[][] 
            {
                new float[] {.3f * tr, .3f * tg, .3f * tb, 0, 0},
                new float[] {.59f * tr, .59f * tg, .59f * tb, 0, 0},
                new float[] {.11f * tr, .11f * tg, .11f * tb, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            });
          ImageAttributes attributes = new ImageAttributes();
          attributes.SetColorMatrix(colorMatrix);
          g.DrawImage(bmp0, new Rectangle(0, 0, bmp0.Width, bmp0.Height),
              0, 0, bmp0.Width, bmp0.Height, GraphicsUnit.Pixel, attributes);
        }
        return bmp1;
    }
