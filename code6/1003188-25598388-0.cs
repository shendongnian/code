    Graphics g = e.Graphics; 
    Pen p = new Pen(Color.Red); 
    Point p1 = new Point(50,50); 
    Point p2 = new Point(1,1); 
    g.DrawLine(p, p1, p2); 
    g.Dispose();
