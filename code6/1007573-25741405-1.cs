    void drawShadow(Graphics G, Color c, GraphicsPath GP, int d)
    {
        int a = (int) (256 / d);
        for (int i = 0; i < d; i++)
        {
            G.TranslateTransform(1f, 1f);  // <== shadow vector!
            using (Pen pen = new Pen(Color.FromArgb(255 - i * a, c)))
                G.DrawPath(pen, GP);
        }
        G.ResetTransform();
    }
    GraphicsPath getRectPath(Rectangle R)
    {
        byte[] fm = new byte[3];
        for (int b = 0; b < 3; b++) fm[b] = 1;
        List<Point> points = new List<Point>();
        points.Add(new Point(R.Left, R.Bottom));
        points.Add(new Point(R.Right, R.Bottom));
        points.Add(new Point(R.Right, R.Top));
        return new GraphicsPath(points.ToArray(), fm);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        using (Graphics G = this.CreateGraphics())
            drawShadow(G, Color.Black, getRectPath(new Rectangle(111, 111, 222, 222)), 17);
    }
