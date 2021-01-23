    Bitmap b = new Bitmap([somewidth], [someheight], PixelFormat.Format24bppRgb);
    using (Graphics g = Graphics.FromImage( b))
    {
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.CopyFromScreen(new Point([your calculated X coordinate], [calculated y coordinate]), new Point(0, 0), new Size(b.Width, b.Height));
    }
