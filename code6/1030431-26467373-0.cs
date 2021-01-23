       using System.Drawing.Imaging;
       using System.Runtime.InteropServices;
       //..   
        // 8-bit grayscale
        Bitmap bmp = new Bitmap(512,512, PixelFormat.Format8bppIndexed);
        List<Color> colors = new List<Color>();
        byte[] data = new byte[512 * 512];
        for (int y = 0; y < 512; y++)
        for (int x = 0; x < 512; x++)
        {
            int v = getValue() + 2048;      // replace by your data reader!
            int r = v >> 4;                 // < here we lose 4 bits!
            int g = r;
            int b = r;
            Color c = Color.FromArgb(r, g, b);
            int cIndex = 0;
            if (colors.Contains(c)) cIndex = colors.IndexOf(c);
            else { colors.Add(c); cIndex = colors.Count; }
                
            //bmp.SetPixel(x,y,c);    // this would be used for rgb formats!
            data[y * 512 + x] = (byte) cIndex;
        }
        // prepare a locked image memory area
        var bmpData = bmp.LockBits(
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.WriteOnly, bmp.PixelFormat);
        // move our data in
        Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
        bmp.UnlockBits(bmpData);
        // create the palette
        var pal = bmp.Palette;
        for (int i = 0; i < colors.Count; i++) pal.Entries[i] = colors[i];
        bmp.Palette = pal;
        // display
        pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        pictureBox1.Image = bmp;
