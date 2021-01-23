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
        //draw line between the points
    }
