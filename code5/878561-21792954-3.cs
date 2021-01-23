    private Point getNearestPointThatMatchesColorWithTolerance(Point i, Color color)
    {
        var maxX = haystack.GetMaxX();
        var maxY = haystack.GetMaxY();
        var match = _shifts.Select(s => new Point(i.X + s[0], i.Y + s[1]))
                           .Where(s => s.X >= 0 && s.X <= maxX)
                           .Where(s => s.Y >= 0 && s.Y <= maxY)
                           .FirstOrDefault(s => colorsMatchWithTolerance(haystack.GetPixel(s.X, s.Y), color));
        return match ?? Point.Empty;
    }
