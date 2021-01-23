    var t = new TextBlock();
    var infiniteSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
    
    t.Text = "Something";
    t.FontSize = 12;
    t.Measure(infiniteSize);
    
    t.LineHeight = t.DesiredSize.Height / 2;
