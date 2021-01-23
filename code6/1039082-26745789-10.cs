    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.IO;
    //..
    // the data array
    int[,] Ks;
    // the offset for cycling
    int koffset = 0;
    // a list of colors
    List<Color> colors = new List<Color>();
    public void paintKs()
    {
        if (Ks == null) return;
        Size s1 = pb_image.ClientSize;
        pb_image.Image = new Bitmap(s1.Width, s1.Height);
        Bitmap bmp = new Bitmap(pb_image.Image);
        PixelFormat fmt1 = bmp.PixelFormat;
        byte bpp1 = 4;
        Rectangle rect = new Rectangle(Point.Empty, s1);
        BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, fmt1);
        int size1 = bmpData.Stride * bmpData.Height;
        byte[] data = new byte[size1];
        System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, size1);
        for (int y = 0; y < s1.Height; y++)
        {
            for (int x = 0; x < s1.Width; x++)
            {
                int index = y * bmpData.Stride + x * bpp1;
                Color c = colors[(Ks[x, y] + koffset) % (colors.Count)];
                if (Ks[x, y] == 0) c = Color.Black;
                data[index + 0] = c.B;
                data[index + 1] = c.G;
                data[index + 2] = c.R;
                data[index + 3] = 255;
            }
        }
        System.Runtime.InteropServices.Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
        bmp.UnlockBits(bmpData);
        pb_image.Image = bmp;
    }
    void saveKs(string dataFile)
    {
       using (BinaryWriter writer = new BinaryWriter(File.Open(dataFile, FileMode.Create)))
       {
            for (int y = 0; y < Ks.GetLength(0); y++)
                for (int x = 0; x < Ks.GetLength(1); x++)
                    writer.Write((Int16)Ks[x, y]);
       }
    }
    void loadKs(string dataFile)
    {
       int w = pb_image.ClientSize.Width;
       if (Ks == null) Ks = new int[w, w];
       using (BinaryReader reader = new BinaryReader(File.Open(dataFile, FileMode.Open)))
       {
            for (int y = 0; y < Ks.GetLength(0); y++)
                for (int x = 0; x < Ks.GetLength(1); x++)
                     Ks[x, y] = reader.ReadInt16();
       }
    }
    private void Test_Click(object sender, EventArgs e)
    {
        loadKs("fractalData021.dat");
        for (int i = 0; i < 256; i++)
        {
            // a very simple and rather awful palette!
            for (int i = 0; i < 256; i++)  
                 colors.Add(Color.FromArgb(255, i, i, 255 - i));
            for (int i = 0; i < 100; i++) 
                 colors.Add(Color.FromArgb(255, i + 100, 255 -i, 155 - i));
            for (int i = 0; i < 100; i++) 
                 colors.Add(Color.FromArgb(255, i + i+ 50, 255 - i - i, 155 - i/2));
        }
        paintKs();
        timer1.Intervall = 33;  // 30 fps
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        koffset++;
        if (koffset >= colors.Count) koffset = 0;;
        paintKs();
    }
