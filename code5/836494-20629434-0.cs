    // your existing code
    Graphics g = e.Graphics;
    g.ScaleTransform(2.0F,2.0F,System.Drawing.Drawing2D.MatrixOrder.Append);
    // say we have some rectangle ...
    Rectangle rcRect = new Rectangle(20, 40, 100, 100);
    
    // make an array of points
    Point[] pPoints =
    {
        new Point(rcRect.Left, rcRect.Top),      // top left
        new Point(rcRect.Right, rcRect.Top),     // top right
        new Point(rcRect.Left, rcRect.Bottom),   // bottom left
        new Point(rcRect.Right, rcRect.Bottom),  // bottom right
    };
    // get a copy of the transformation matrix
    Matrix mat = g.Transform;
    // use it to transform the points
    mat.TransformPoints(pPoints);
