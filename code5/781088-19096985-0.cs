    private Point3 RotatePoint(Point3 p0, int angle)
    {
        Point3 p =  new Point3()
        {
            X = p0.X * Math.Cos(angle) - p0.Y * Math.Sin(angle),
            Y = p0.X * Math.Sin(angle) + p0.Y * Math.Cos(angle),
            Z = p0.Z,
        };
    
        return p;
    }
