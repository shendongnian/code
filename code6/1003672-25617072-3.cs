    public Bitmap getAreaFrom(Control ctl, Rectangle area)
    {
        Bitmap bmp2 = new Bitmap(area.Width, area.Height);
        using (Graphics G = ctl.CreateGraphics())
        using (Bitmap bmp = new Bitmap(ctl.ClientSize.Width, ctl.ClientSize.Height))
        {
            ctl.DrawToBitmap(bmp, ctl.ClientRectangle);
            using (Graphics G2 = Graphics.FromImage(bmp2))
                G2.DrawImage(bmp, 0f, 0f, area, GraphicsUnit.Pixel);
        }
        return bmp2;
    }
