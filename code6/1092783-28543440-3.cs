    List<GraphicsPath> segments = new List<GraphicsPath>();
    PointF center = Point.Empty;
    private void Form4_Load(object sender, EventArgs e)
    {
         center = new PointF(pb_target.Width / 2f, pb_target.Height / 2f);
         float angle = 60f;
         for (int i = 0; i < 360 / angle; i++)
         {
            segments.Add(getSegment(center, pb_target.Width / 2.5f, 
                                    pb_target.Width / 4f, i * angle, angle));
         }
    }
    GraphicsPath getSegment(PointF center, float radius, float width, 
                            float startAngle, float angle)
    {
        GraphicsPath gp = new GraphicsPath();
        float radI = radius - width;
        RectangleF OunterBounds = 
          new RectangleF(center.X - radius, center.Y - radius, 2 * radius, 2 * radius);
        RectangleF InnerBounds = 
          new RectangleF(center.X - radI, center.Y - radI, 2 * radI, 2 * radI);
        gp.AddArc(OunterBounds, startAngle, angle);
        gp.AddArc(InnerBounds, startAngle + angle, -angle);
        gp.CloseFigure();
        return gp;
    }
    private void pb_target_Paint(object sender, PaintEventArgs e)
    {
        for (int i = 0; i < segments.Count; i++)
        {
            GraphicsPath gp = segments[i];
            e.Graphics.FillPath(Brushes.Gainsboro, gp);
            e.Graphics.DrawPath(Pens.SlateBlue, gp);
        }
    }
