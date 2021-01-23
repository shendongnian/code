    private void panel1_Paint_1(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        Color col = Color.Black;
        for (int i = 0; i < 7; i++ )
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(80 - i * 10, col)))
            { g.FillEllipse(brush, panel1.ClientRectangle.X + i*2, panel1.ClientRectangle.Y + i, 60, 60); }
        using (SolidBrush brush = new SolidBrush(col))
            g.FillEllipse(brush, panel1.ClientRectangle.X, panel1.ClientRectangle.Y, 60, 60);
        // moving a little to the right to keep the same code otherwise
        g.TranslateTransform(80, 0);
        for (int i = 0; i < 7; i++ )
            using (Pen pen = new Pen(Color.FromArgb(80 - i * 10, col), 2.5f))
            { g.DrawEllipse(pen, panel1.ClientRectangle.X + i * 1.25f , panel1.ClientRectangle.Y + i, 60, 60); }
        using (Pen pen = new Pen(col))
            g.DrawEllipse(pen, panel1.ClientRectangle.X, panel1.ClientRectangle.Y, 60, 60);
    }
