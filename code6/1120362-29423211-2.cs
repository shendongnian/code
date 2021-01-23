    void PutPixel(Graphics g, int x, int y, Color c) // sadece bir pixel icin
    {
        System.Drawing.Bitmap bm = new System.Drawing.Bitmap(10, 10);
        bm.SetPixel(0, 0, Color.DarkRed);
        g.DrawImageUnscaled(bm, x, y);
    }
