    private void panel2_Paint(object sender, PaintEventArgs e)
    {
        int dotstoDraw = 666*4;
        Random R = new Random();
        Size s1x1 = new System.Drawing.Size(2, 2);
        int radius = 200;
        int off = 20;
        Rectangle bounds = new Rectangle(off, off, radius, radius);
        GraphicsPath gp = new GraphicsPath();
        gp.AddEllipse(bounds);
        e.Graphics.Clear(Color.AntiqueWhite);
        e.Graphics.DrawEllipse(Pens.Black, bounds);
        int count = 0;
        do
        {
            Point p = new Point(off + R.Next(radius), off + R.Next(radius));
            if (gp.IsVisible(p))
            {
                e.Graphics.FillEllipse(Brushes.Red, new Rectangle(p, s1x1));
                count++;
            }
        } while (count < dotstoDraw);
     }
