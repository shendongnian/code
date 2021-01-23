    var clip = new RectangleGeometry(new Rect(50, 50, 10, 10));
    var geometry = new PathGeometry(new[] { new PathFigure(new Point(0, 0), new[] {
        new LineSegment(new Point(0, 100), true),
        new LineSegment(new Point(100, 100), true),
        new LineSegment(new Point(100, 0), true),
    }, true) });
    path.Data = Geometry.Combine(clip, geometry, GeometryCombineMode.Intersect, null);
