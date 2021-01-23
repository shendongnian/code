    for (System.Drawing.Point point in Points)
    {
        xCenterOfMass +=  point.X;
        yCenterOfMass +=  point.Y;
    }
    xCenterOfMass /= Points.Count();
    yCenterOfMass /= Points.Count();
