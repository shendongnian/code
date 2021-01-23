    Bitmap mixBitmaps(Bitmap bmp1, Bitmap bmp2)
    {
        using (Graphics G = Graphics.FromImage(bmp1) )
        {
            G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            G.DrawImage(bmp2, Point.Empty);
        }
        return bmp1;
    }
