    public int[][] _shifts = {
        new [] { 0, 0 },
        new [] { 1, 0 }, new [] { -1, 0 }, new [] { 0, -1 }, new [] { 0, 1 }
        // (...)
    };
    private Point getNearestPointThatMatchesColorWithTolerance(Point i, Color color)
    {
        var match = _shifts.Select(s => new Point(i.X + s[0], i.Y + s[1]))
                           .FirstOrDefault(s => colorsMatchWithTolerance(haystack.GetPixel(s.X, s.y), color));
        return match ?? Point.Empty;
    }
