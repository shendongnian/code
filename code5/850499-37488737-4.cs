    List<GraphicsPath> getPaths(ChartArea ca, Series ser, double limit)
    {
        List<GraphicsPath> paths = new List<GraphicsPath>();
        List<PointF> points = new List<PointF>();
        int first = 0;
        float limitPix = (float)ca.AxisY.ValueToPixelPosition(limit);
        for (int i = 0; i < ser.Points.Count; i++)
        {
            if ((ser.Points[i].YValues[0] > limit) && (i < ser.Points.Count - 1))
            {
                if (points.Count == 0) first = i;  // remember group start
                // insert very first point:
                if (i == 0) points.Insert(0, new PointF( 
                     (float)ca.AxisX.ValueToPixelPosition(ser.Points[0].XValue), limitPix));
                
                points.Add( pointfFromDataPoint(ser.Points[i], ca)); // the regular points
            }
            else
            {
                if (points.Count > 0)
                {
                    if (first > 0)  points.Insert(0, median(  
                                      pointfFromDataPoint(ser.Points[first - 1], ca),
                                      pointfFromDataPoint(ser.Points[first], ca), limitPix));
                    if (i == ser.Points.Count - 1)
                    {
                        if ((ser.Points[i].YValues[0] > limit)) 
                             points.Add(pointfFromDataPoint(ser.Points[i], ca));
                   points.Add(new PointF( 
                      (float)ca.AxisX.ValueToPixelPosition(ser.Points[i].XValue), limitPix));
                    }
                    else
                        points.Add(median(pointfFromDataPoint(ser.Points[i - 1], ca),
                                     pointfFromDataPoint(ser.Points[i], ca), limitPix));
                    GraphicsPath gp = new GraphicsPath();
                    gp.FillMode = FillMode.Winding;
                    gp.AddLines(points.ToArray());
                    gp.CloseFigure();
                    paths.Add(gp);
                    points.Clear();
                }
            }
        }
        return paths;
    }
