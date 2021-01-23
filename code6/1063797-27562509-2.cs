    var g = this.CreateGraphics();
    var blackPen = new Pen(Brushes.Black, 3);
    g.DrawLine(blackPen, pts[0], pts[0]);
    
    for(i = 1; i < pts.Length; i++)
       g.DrawLine(blackPen, pts[i - 1], pts[i]);
