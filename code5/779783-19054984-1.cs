    Point oldPoint = Point.Empty;
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        Point newPoint = e.Location;
    
        if (oldPoint != Point.Empty)
            DrawLine(oldPoint, newPoint);
    
        //save away as oldpoint
        oldPoint = newPoint;
    }
    
    void DrawLine(Point from, Point to)
    {
        //calculate the length of distance between from and to
        int xdiff = to.X - from.X;
        int ydiff = to.Y - from.Y;
        double length = Math.Sqrt(xdiff * xdiff + ydiff * ydiff);
        //if the length is zero exit here (or else divide by zero happens below)
        if (length == 0)
            return;
    
        //nx are the normalized xdiff and ydiff used for travelling along the line in
        //equal units below
        double nx = xdiff / length;
        double ny = ydiff / length;
    
        //draw ellipses along the line every 4 pixels (lowering it from 4 increases the draw
        //smoothness but at the cost of performance)
        for (int i = 0; i <= length; i += 4)
        {
            //the point along the line to draw an ellipse
            double px = from.X + nx * i;
            double py = from.Y + ny * i;
    
            //where px and py are the center of the ellipse, this draws a 10x10 ellipse
            //with that center
            g.FillEllipse(Brushes.Blue, (float)px - 5, (float)py - 5, 10, 10); 
        }
    }
