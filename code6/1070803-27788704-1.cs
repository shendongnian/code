    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
      if(sender is ChartArea)
      {
        ChartArea area = (ChartArea)sender;
        if(area.Name == "Default")
        {
            // Get Graphics object from chart
            Graphics graph = e.ChartGraphics.Graphics;
            // Convert X and Y values to screen position
            float pixelYMax = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,1);
            float pixelXMax = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,0);
            float pixelYMin = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,0);
            float pixelXMin = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,0);
            PointF point1 = PointF.Empty;
            PointF point2 = PointF.Empty;
            // Set Maximum and minimum points
            point1.X = pixelXMax;
            point1.Y = pixelYMax;
            point2.X = pixelXMin;
            point2.Y = pixelYMin;
            // Convert relative coordinates to absolute coordinates.
            point1 = e.ChartGraphics.GetAbsolutePoint(point1);
            point2 = e.ChartGraphics.GetAbsolutePoint(point2);
            // Draw connection line
            graph.DrawLine(new Pen(Color.Yellow,3), point1,point2);
        }
      }
    }
