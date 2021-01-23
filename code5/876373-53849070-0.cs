    public static double GetLengthOfGeo(Geometry geo)
    {
        PathGeometry pg = PathGeometry.CreateFromGeometry(geo);
        Point p; Point tp;
        pg.GetPointAtFractionLength(0.0001, out p, out tp);
        return (pg.Figures[0].StartPoint - p).Length*10000;
    
    }
