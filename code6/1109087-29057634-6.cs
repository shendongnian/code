    Point a = new Point(0, 200);
    Point c = new Point(200, 200);
    for (int i = 1; i < 10; i++)
    {
        e.Graphics.TranslateTransform(0, -5);
        Point b = new Point(100, 50);
        Point b0 = new Point(100, a.Y + (a.Y - b.Y));
        e.Graphics.DrawCurve(Pens.Maroon, new[] { b0, a, b, c, b0 }, 1, 2, 0.1f * i);
    }
    e.Graphics.ResetTransform();
    Point pa = new Point(250, 200);
    Point pb = new Point(450, 200);
    for (int i = 0; i < 10; i++)
    {
        e.Graphics.TranslateTransform(0, -5);
        Point ca = new Point(350 - i * 9, 100 - i * 5);
        Point cb = new Point(350 + i * 9, 100 - i * 5);
        e.Graphics.DrawBezier(Pens.ForestGreen, pa, ca, cb, pb);
    }
    e.Graphics.ResetTransform();
