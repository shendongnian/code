    public static int GetX(int y, Point a, Point b)
    {
        var m = CalculateSlope(a, b);
        // Horizontal line (x-values are always the same)
        if (m == 0.0)
            return a.X;
        var c = a.Y - a.X * m;
        return Convert.ToInt32((y - c) / m);
    }
    
    public static int GetY(int x, Point a, Point b)
    {
        var m = CalculateSlope(a, b);
        // Vertical line (y-values are always the same)
        if (double.IsPositiveInfinity(m))
            return a.Y;
        var c = a.Y - a.X * m;
        return Convert.ToInt32(m * x + c);
     }
    public static double CalculateSlope(Point a, Point b)
    {
        if (b.Y == a.Y)
            return double.PositiveInfinity;
    
        if (b.X == a.X)
            return 0.0;
    
        return (Convert.ToDouble(b.Y) - Convert.ToDouble(a.Y)) / (Convert.ToDouble(b.X) - Convert.ToDouble(a.X));
    }
