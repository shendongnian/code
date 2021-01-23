    List<PointF> ReducePath(List<PointF> points, float epsilon)
    {
        if (points.Count < 3) return points;
        var newPoints = new List<PointF>();
        newPoints.Add(points[0]);
        float delta = 0f;
        for (int i = 1; i < points.Count - 1; i++)
        {
            float slope = Slope(points[i-1], points[i]);
            delta += slope;
            if (Math.Abs(delta) > epsilon)
            {
                delta = 0;
                newPoints.Add(points[i]);
            }
        }
        newPoints.Add(points[ points.Count -1]);
        return newPoints;
    }
    float Slope(PointF p1, PointF p2)
    {
        if (p1.Y == p2.Y) return 0;
        else if (p1.X == p2.X) return 12345;
        else return (p1.Y - p2.Y)/(p1.X - p2.X);
    }
