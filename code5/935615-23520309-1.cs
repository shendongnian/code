    public static Point[] GetIntersectionPoints(Geometry g1, Geometry g2)
    {
        Geometry og1 = g1.GetWidenedPathGeometry(new Pen(Brushes.Black, 1.0));
        Geometry og2 = g2.GetWidenedPathGeometry(new Pen(Brushes.Black, 1.0));
        CombinedGeometry cg = new CombinedGeometry(GeometryCombineMode.Intersect, og1, og2);
     
        PathGeometry pg = cg.GetFlattenedPathGeometry();
        Point[] result = new Point[pg.Figures.Count];
    
        for (int i = 0; i < pg.Figures.Count; i++)
        {
            Rect fig = new PathGeometry(new PathFigure[] { pg.Figures[i] }).Bounds;
            result[i] = new Point(fig.Left + fig.Width / 2.0, fig.Top + fig.Height / 2.0);
        }
        return result;
    }
