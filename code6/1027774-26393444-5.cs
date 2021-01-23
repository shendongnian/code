    private void TestButton_Click(object sender, EventArgs e)
    {
        Point A = new Point(5, 50);
        Point B = new Point(250, 100);
        Point C = new Point(50, 250);
        List<Point> points = new List<Point>();
        points.Add(A);
        points.Add(B);
        points.Add(C);
        points.Add(A);  // *
        points.Add(B);  // *
        GP = roundedPolygon(points.ToArray(), 20);
        panel1.Invalidate();
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
       if (GP == null) return;
       using (Pen pen = new Pen(Brushes.BlueViolet, 3f))
              e.Graphics.DrawPath(pen, GP);
    }
    GraphicsPath roundedPolygon(Point[] points, int rounding)
    {
        GraphicsPath GP = new GraphicsPath();
        List<Line> lines = new List<Line>();
        for (int p = 0; p < points.Length - 1; p++)
            lines.Add( shortenLine(new Line(points[p], points[p+1]), rounding) );
        for (int l = 0; l < lines.Count - 1; l++)
        {
            GP.AddLine(lines[l].P1, lines[l].P2);
            GP.AddCurve(new Point[] { lines[l].P2, 
                                      supPoint(lines[l].P2,points[l+1], lines[l+1].P1), 
                                      lines[l+1].P1 });
        }
        return GP;
    }
    // a simple structure
    struct Line
    {
        public Point P1; public Point P2;
        public Line(Point p1, Point p2){P1 = p1; P2 = p2;}
    }
    // routine to make a line shorter on both ends
    Line shortenLine(Line line, int byPixels)
    {
        float len = (float)Math.Sqrt(Math.Pow(line.P1.X - line.P2.X, 2)
                                   + Math.Pow(line.P1.Y - line.P2.Y, 2));
        float prop = (len - byPixels) / len;
        Point p2 = pointBetween(line.P1, line.P2, prop);
        Point p1 = pointBetween(line.P1, line.P2, 1 - prop);
        return new Line(p1,p2);
    }
    // with a proportion of 0.5 the point sits in the middle
    Point pointBetween(Point p1, Point p2, float prop)
    {
        return new Point((int)(p1.X + (p2.X - p1.X) * prop), 
                         (int)(p1.Y + (p2.Y - p1.Y) * prop));
    }
    // a supporting point, change the second prop (**) to change the rounding shape! 
    Point supPoint(Point p1, Point p2, Point p0)
    {
        Point p12 = pointBetween(p1, p2, 0.5f);
        return pointBetween(p12, p0, 0.5f);       // **
    }
