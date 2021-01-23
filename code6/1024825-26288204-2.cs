    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        float stepX = panel1.ClientSize.Width / 100f;
        float stepY = panel1.ClientSize.Height / 100f;
        for (int y = 1; y <=  100; y++)
        for (int x = 1; x <=  100; x++)
        {
            HSV hsv = new HSV(trackBar1.Value,  x / 100f,  y / 100f );
            using (SolidBrush brush = new SolidBrush(ColorFromHSV(hsv)))
            e.Graphics.FillRectangle(brush, 
                                     new RectangleF(x * stepX, y * stepY, stepX, stepY));
        }
    }
    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        panel1.Invalidate();
        label1.Text = trackBar1.Value.ToString() + "°";
    }
    public struct HSV
    {
        public float h; public float s; public float v;
        public HSV(float h_, float s_, float v_) { h = h_; s = s_; v = v_; }
    }
    static public Color ColorFromHSV(HSV hsv)
    {
        int hi = Convert.ToInt32(Math.Floor(hsv.h / 60)) % 6;
        double f = hsv.h / 60 - Math.Floor(hsv.h / 60);
        double value = hsv.v * 255;
        int v = Convert.ToInt32(value);
        int p = Convert.ToInt32(value * (1 - hsv.s));
        int q = Convert.ToInt32(value * (1 - f * hsv.s));
        int t = Convert.ToInt32(value * (1 - (1 - f) * hsv.s));
        if (hi == 0)
            return Color.FromArgb(255, v, t, p);
        else if (hi == 1)
            return Color.FromArgb(255, q, v, p);
        else if (hi == 2)
            return Color.FromArgb(255, p, v, t);
        else if (hi == 3)
            return Color.FromArgb(255, p, q, v);
        else if (hi == 4)
            return Color.FromArgb(255, t, p, v);
        else
            return Color.FromArgb(255, v, p, q);
    }
