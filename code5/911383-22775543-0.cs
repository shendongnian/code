    var t = new TextBlock();
    var infiniteSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
     
    t.Measure(infiniteSize);
    
    t.LineHeight = t.DesiredSize.Height / 2;
