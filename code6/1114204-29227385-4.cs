    private void panel1_Paint_1(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        Color color = Color.Blue;
        Color shadow = Color.FromArgb(255, 16, 16, 16);
        for (int i = 0; i < 8; i++ )
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(80 - i * 10, shadow)))
            { g.FillEllipse(brush, panel1.ClientRectangle.X + i*2, panel1.ClientRectangle.Y + i, 60, 60); }
        using (SolidBrush brush = new SolidBrush(color))
            g.FillEllipse(brush, panel1.ClientRectangle.X, panel1.ClientRectangle.Y, 60, 60);
        // move to the right to use the same coordinates again for the drawn shape
        g.TranslateTransform(80, 0);
        for (int i = 0; i < 8; i++ )
            using (Pen pen = new Pen(Color.FromArgb(80 - i * 10, shadow), 2.5f))
            { g.DrawEllipse(pen, panel1.ClientRectangle.X + i * 1.25f , panel1.ClientRectangle.Y + i, 60, 60); }
        using (Pen pen = new Pen(color))
            g.DrawEllipse(pen, panel1.ClientRectangle.X, panel1.ClientRectangle.Y, 60, 60);
    }
