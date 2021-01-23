    private Bitmap CaptureControl(Control ctl)
    {
        Rectangle rect;
        if (ctl is Form)
            rect = new Rectangle(ctl.Location, ctl.Size);
        else
            rect = new Rectangle(ctl.PointToScreen(new Point(0, 0)), ctl.Size);
        Bitmap bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format64bppPArgb);
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
        }
        return bitmap;
    }
