    Bitmap aspect;
    void CloneAspect(object sender, PaintEventArgs e)
    {
        if(aspect == null || aspect.Width != panel.Width || aspect.Height != panel.Height)
        {
             if(aspect != null)
                aspect.Dispose();
             aspect = new Bitmap(panel.Width, panel.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        }
        panel.DrawToBitmap(aspect, new Rectangle(0,0, panel.Width, panel.Height);
    }
