    using System.Linq;
    ...
    private static List<Point> GetPolylinePoints(PathGeometry geometry)
    {
        var points = new List<Point>();
        foreach (var figure in geometry.Figures)
        {
            points.Add(figure.StartPoint);
            foreach (var segment in figure.Segments.OfType<PolyLineSegment>())
            {
                points.AddRange(segment.Points);
            }
        }
        return points;
    }
