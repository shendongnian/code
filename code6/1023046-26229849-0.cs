    var polylines = this.CanvasDraw.Children.Cast<Polyline>();
    
    // project all points into the one list
    var allPoints = polyline.SelectMany(pl=>pl.Points).ToList();
    // get mins and maxes
    var minX = allPoints.Min(p=>p.X);
    var minY = allPoints.Min(p=>p.Y);
    var maxX = allPoints.Max(p=>p.X);
    var maxY = allPoints.Max(p=>p.Y);
    // create bounding points
    Point Topleft = new Point(minX, minY);
    Point BottomRight = new Point(maxX, maxY);
