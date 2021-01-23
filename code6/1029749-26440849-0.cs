    double minX = 25.52524938052284;
    double minY = 44.267051317656474;
    double maxX = 25.525239580522843;
    double maxY = 44.26684671765647;
    double diffX = maxX - minX;         // -0.0000097999999972842033
    double diffY = maxY - minY;         // -0.00020460000000355194
    // setting values to positive small differences
    minX = 25.525d;
    minY = 44.266d;
    maxX = 25.526d;
    maxY = 44.267d;
    System.Windows.Point point1 = new System.Windows.Point(minX, minY);
    System.Windows.Point point2 = new System.Windows.Point(maxX, maxY);
    Polyline myPolyline = new Polyline();
    myPolyline.Stroke = System.Windows.Media.Brushes.SaddleBrown;
    myPolyline.StrokeThickness = 0.0003d;  // <-- necessary due to scaling
    myPolyline.Points.Add(point1);
    myPolyline.Points.Add(point2);
    System.Windows.Point center = new System.Windows.Point();
    center.X = minX + ((maxX - minX) / 2.0d) - 0.001d;
    center.Y = minY + ((maxY - minY) / 2.0d) - 0.001d;
    double scale = 100000.0d;
    //ScaleTransform st = new ScaleTransform(100000, 100000, 25, 25);
    ScaleTransform st = new ScaleTransform(scale, scale, center.X, center.Y);
    myPolyline.RenderTransform = st;
    //TranslateTransform tt = new TranslateTransform(100, 100);
    //myPolyline.RenderTransform = tt;
    canvas.Children.Add(myPolyline);
