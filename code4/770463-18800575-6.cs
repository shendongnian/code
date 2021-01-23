    using System.Linq;
    ...
    private static PointCollection GetPolylinePoints(PathFigure figure)
    {
        var points = new PointCollection();
        points.Add(figure.StartPoint);
        foreach (var segment in figure.Segments.OfType<PolyLineSegment>())
        {
            foreach (var point in segment.Points)
            {
                points.Add(point);
            }
        }
        return points;
    }
