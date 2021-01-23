    [Rectangle r = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
    System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
    int d = 50;
    gp.AddArc(r.X, r.Y, d, d, 180, 90);
    gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
    gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
    gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
    pictureBox1.Region = new Region(gp);][2]
