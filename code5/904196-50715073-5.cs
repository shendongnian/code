    List<PointF> ReducePath(List<PointF> points, float epsilon)
    {
        if (points.Count < 3) return points;
        var newPoints = new List<PointF>();
        newPoints.Add(points[0]);
        float delta = 0f;
        for (int i = 1; i < points.Count - 1; i++)
        {
            float ang = Angle(points[i-1], points[i])/10f;
            delta += ang ;
            if (Math.Abs(delta) > epsilon)
            {
                delta = 0;
                newPoints.Add(points[i]);
            }
        }
        newPoints.Add(points[ points.Count -1]);
        return newPoints;
    }
    float Angle(PointF p1, PointF p2)
    {
        if (p1.Y == p2.Y) return p1.X > p2.Y ? 0 : 180;
        else if (p1.X == p2.X) return p1.Y > p2.Y ? 90 : 270;
        else return (float)Math.Atan((p1.Y - p2.Y)/(p1.X - p2.X));
    }
    //float Slope(PointF p1, PointF p2)
    //{
    //    if (p1.Y == p2.Y) return 0;
    //    else if (p1.X == p2.X) return 12345;
    //    else return (p1.Y - p2.Y)/(p1.X - p2.X);
    //}
