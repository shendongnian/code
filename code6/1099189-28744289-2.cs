    public static void DrawString (this Graphics g, Bitmap bmp, string text, Font font, PointF point) {
        SizeF sf = g.MeasureString (text, font);
        Rectangle r = new Rectangle (Point.Truncate (point), Size.Ceiling (sf));
        r.Intersect (new Rectangle(0,0,bmp.Width,bmp.Height));
        Color brsh = MostDifferent (AverageColor (bmp, r));
        g.DrawString (text, font, new SolidBrush (brsh), point);
    }
