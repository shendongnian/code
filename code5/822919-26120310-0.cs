    public static bool[][] Image2Bool(Image img)
    {
        Bitmap bmp = new Bitmap(img);
        bool[][] s = new bool[bmp.Height][];
        for (int y = 0; y < bmp.Height; y++ )
        {
            s[y] = new bool[bmp.Width];
            for (int x = 0; x < bmp.Width; x++)
                s[y][x] = bmp.GetPixel(x, y).GetBrightness() < 0.3;
        }
        return s;
    }
    public static Image Bool2Image(bool[][] s)
    {
        Bitmap bmp = new Bitmap(s[0].Length, s.Length);
        using (Graphics g = Graphics.FromImage(bmp)) g.Clear(Color.White);
        for (int y = 0; y < bmp.Height; y++)
            for (int x = 0; x < bmp.Width; x++)
                if (s[y][x]) bmp.SetPixel(x, y, Color.Black);
        return (Bitmap)bmp;
    }
