    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Point a = new Point(0, 200);
        Point c = new Point(200, 200);
        for (int i = 0; i< 10; i++)
        {
            e.Graphics.TranslateTransform(0, -5);
            Point b = new Point(100, 50 + i * 10);
            e.Graphics.DrawCurve(Pens.Maroon, new[] { a, b, c }, 0.7f);
        }
        e.Graphics.ResetTransform();
        Point pa = new Point(250, 200);
        Point pb = new Point(450, 200);
        for (int i = 0; i < 10; i++)
        {
            e.Graphics.TranslateTransform(0, -5);
            Point pc = new Point(350, 200 - i * 10);
            e.Graphics.DrawBezier(Pens.ForestGreen, pa, pc, pc, pb);
        }
        e.Graphics.ResetTransform();
        int x = 500;
        int y0 = 200;
        int w = 200;
        for (int i = 0; i < 10; i++)
        {
            e.Graphics.TranslateTransform(0, -5);
            Rectangle rect = new Rectangle(x, y0 - i * 10, w, 10 + i * 10);
            e.Graphics.DrawArc(Pens.DarkBlue, rect, -0, -180);
        }
        e.Graphics.ResetTransform();
    }
