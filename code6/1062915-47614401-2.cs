    public Geometry translateGeo(Geometry baseGeo, Point translate)
    {
        // sweeps a geometry linearly from current location through vector
        Debug.WriteLine("Translating Geometry");
        Debug.WriteLine("Original Outline Verticies: " + CountVerticies(baseGeo.GetFlattenedPathGeometry()));
        Geometry sweptPathGeo = baseGeo.Clone();
        Geometry capGeo = baseGeo.Clone();
       
        capGeo.Transform = new TranslateTransform(translate.X, translate.Y);
        sweptPathGeo = new CombinedGeometry(GeometryCombineMode.Union, sweptPathGeo, capGeo);
        sweptPathGeo = sweptPathGeo.GetFlattenedPathGeometry();
        geometry = sweptPathGeo.Clone();
        PathGeometry pathGeo = baseGeo.GetFlattenedPathGeometry();
        foreach (PathFigure figure in pathGeo.Figures)
        {
            Point startPoint = figure.StartPoint;
            //Debug.WriteLine(startPoint.X + ", " + startPoint.Y);
            foreach (PathSegment segment in figure.Segments)
            {
                PolyLineSegment polySegment = segment as PolyLineSegment;
                if (polySegment != null)
                {
                    foreach (Point point in polySegment.Points)
                    {
                        sweptPathGeo = new CombinedGeometry(GeometryCombineMode.Union, sweptPathGeo, getShadow(startPoint, point, translate));
                        startPoint = point;
                    }
                }
                LineSegment lineSegment = segment as LineSegment;
                if (lineSegment != null)
                {
                    sweptPathGeo = new CombinedGeometry(GeometryCombineMode.Union, sweptPathGeo, getShadow(startPoint, lineSegment.Point, translate));
                    startPoint = lineSegment.Point;
                }
            }
        }
        //sweptPathGeo = sweptPathGeo.GetOutlinedPathGeometry();
        Debug.WriteLine("Finale Outline Verticies: " + CountVerticies(sweptPathGeo.GetFlattenedPathGeometry()));
        return sweptPathGeo;
    }
    public Geometry getShadow(Point startPoint, Point endPoint, Point translate)
    {
        PointCollection points = new PointCollection();
        points.Add(startPoint);
        points.Add(endPoint);
        points.Add(new Point(endPoint.X + translate.X, endPoint.Y + translate.Y));
        points.Add(new Point(startPoint.X + translate.X, startPoint.Y + translate.Y));
        points.Add(startPoint);
        Polygon poly = new Polygon();
        poly.Points = points;
        poly.Arrange(geometry.Bounds);
        poly.Measure(geometry.Bounds.Size);
            PathGeometry returnGeo = poly.RenderedGeometry.GetOutlinedPathGeometry();
        return returnGeo;
        //foreach (Point point in points) Debug.WriteLine(point.X + ", " + point.Y);
    }
    private int CountVerticies(PathGeometry geo)
    {
        int verticies = 0;
        foreach (PathFigure figure in geo.Figures)
        {
            Point startPoint = figure.StartPoint;
            verticies += 1;
            foreach (PathSegment segment in figure.Segments)
            {
                PolyLineSegment polySegment = segment as PolyLineSegment;
                if (polySegment != null) verticies += polySegment.Points.Count;
                
                LineSegment lineSegment = segment as LineSegment;
                if (lineSegment != null) verticies += 1;
            }
        }
        return verticies;
    }
