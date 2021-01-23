    Bitmap Transparent2Color(Bitmap bmp1, Color target)
    {
        Bitmap bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
        Rectangle rect = new Rectangle(Point.Empty, bmp1.Size);
        using (Graphics G = Graphics.FromImage(bmp2) )
        {
            G.Clear(target);
            G.DrawImageUnscaledAndClipped(bmp1, rect);
        }
        return bmp2;
    }
