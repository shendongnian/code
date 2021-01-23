    private void panel2_Paint(object sender, PaintEventArgs e)
    {
        int dotsPerQuadrant = 666;
        Random R = new Random();
        Size s1x1 = new System.Drawing.Size(2, 2);
        int radius = 200;
        int rad2 = radius / 2;
        int off = 20;
        Rectangle bounds = new Rectangle(off, off, radius, radius);
        GraphicsPath gp = new GraphicsPath();
        gp.AddEllipse(bounds);
        Rectangle rectQ1 = new Rectangle(off, off, rad2, rad2);
        Rectangle rectQ2 = new Rectangle(off + rad2, off, rad2, rad2);
        Rectangle rectQ3 = new Rectangle(off, off + rad2, rad2, rad2);
        Rectangle rectQ4 = new Rectangle(off + rad2, off + rad2, rad2, rad2);
        List<Rectangle> quadrants = new List<Rectangle> { rectQ1, rectQ2, rectQ3, rectQ4 };
        e.Graphics.Clear(Color.AntiqueWhite);
        e.Graphics.DrawEllipse(Pens.Black, bounds);
        foreach (Rectangle rect in quadrants)
        {
            int count = 0;
            do
            {
                Point p = new Point(rect.X + R.Next(rad2), rect.Y + R.Next(rad2));
                if (gp.IsVisible(p))
                {
                    e.Graphics.FillEllipse(Brushes.Red, new Rectangle(p, s1x1));
                    count++;
                }
            } while (count < dotsPerQuadrant);
        }
    }
