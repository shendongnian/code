    // Add the Polyline Element
    myPolyline = new Polyline();
    myPolyline.Stroke = System.Windows.Media.Brushes.SlateGray;
    myPolyline.StrokeThickness = 2;
    myPolyline.FillRule = FillRule.EvenOdd;
    System.Windows.Point Point4 = new System.Windows.Point(1, 50);
    System.Windows.Point Point5 = new System.Windows.Point(10, 80);
    System.Windows.Point Point6 = new System.Windows.Point(20, 40);
    PointCollection myPointCollection2 = new PointCollection();
    myPointCollection2.Add(Point4);
    myPointCollection2.Add(Point5);
    myPointCollection2.Add(Point6);
    myPolyline.Points = myPointCollection2;
    myGrid.Children.Add(myPolyline);
