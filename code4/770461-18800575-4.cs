    using System.Linq;
    ...
    private static PointCollection GetPolylinePoints(PathGeometry geometry)
    {
        var points = new PointCollection();
        foreach (var figure in geometry.Figures)
        {
            points.Add(figure.StartPoint);
            foreach (var segment in figure.Segments.OfType<PolyLineSegment>())
            {
                foreach (var point in segment.Points)
                {
                    points.Add(point);
                }
            }
        }
        return points;
    }
