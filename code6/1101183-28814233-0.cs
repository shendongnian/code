    public static Bitmap ConvertTextToImage(string txt, string fontname, int fontsize, Color bgcolor, Color fcolor, int width, int Height)
    {
        var bmp = new Bitmap(width, Height);
        using (var graphics = Graphics.FromImage(bmp))
        using (var font = new Font(fontname, fontsize))
        {
            graphics.FillRectangle(new SolidBrush(bgcolor), 0, 0, bmp.Width, bmp.Height);
            graphics.DrawString(txt, font, new SolidBrush(fcolor), 0, 0);
        }
        bmp.Save("C:\\" + Guid.NewGuid() + ".bmp");
        Convert(bmp);
        return bmp;
    }
