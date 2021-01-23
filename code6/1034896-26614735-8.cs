    Bitmap expandCanvas(Bitmap bmp, Size size)
    {
        float f1 = 1f * bmp.Width / bmp.Height;
        float f2 = 1f * size.Width / size.Height;
        Size newSize = size;
        if (f1 > f2) newSize = new Size(bmp.Width, (int)(bmp.Height * f1));
        else if (f1 < f2) newSize = new Size((int)(bmp.Width / f1), bmp.Height);
        Bitmap bmp2 = new Bitmap(newSize.Width, newSize.Height);
        bmp2.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
        Rectangle RDest = new Rectangle(Point.Empty, bmp.Size);
        Rectangle RTgt = new Rectangle(Point.Empty, newSize);
        using (Graphics G = Graphics.FromImage(bmp2))
        {
            G.DrawImage(bmp, RDest, RDest, GraphicsUnit.Pixel);
        }
        return bmp2;
    }
