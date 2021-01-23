    // we create a general LineAnnotation, ie not Vertical or Horizontal:
    LineAnnotation lan = new LineAnnotation();
    // we use Axis scaling, not chart scaling
    lan.IsSizeAlwaysRelative = false;
    lan.LineColor = Color.Yellow;
    lan.LineWidth = 5;
    // the coordinates of the starting point in axis measurement
    lan.X = 3.5d;
    lan.Y = 0d;
    // the size: 
    lan.Width = -3.5d;
    lan.Height = 5.5d;
    // looks like we need an anchor point, no matter which..
    lan.AnchorDataPoint = yourSeries.Points[0];
    // now we can add the LineAnnotation;
    chart1.Annotations.Add(lan);
