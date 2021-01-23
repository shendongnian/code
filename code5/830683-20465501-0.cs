    //Add the Polygon Element
    myPolygon = new Polygon();
    myPolygon.Stroke = System.Windows.Media.Brushes.Black;
    myPolygon.Fill = System.Windows.Media.Brushes.LightSeaGreen;
    myPolygon.StrokeThickness = 2;
    myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
    myPolygon.VerticalAlignment = VerticalAlignment.Center;
    System.Windows.Point Point1 = new System.Windows.Point(1, 50);
    System.Windows.Point Point2 = new System.Windows.Point(10,80);
    System.Windows.Point Point3 = new System.Windows.Point(50,50);
    PointCollection myPointCollection = new PointCollection();
    myPointCollection.Add(Point1);
    myPointCollection.Add(Point2);
    myPointCollection.Add(Point3);
    myPolygon.Points = myPointCollection;
    myGrid.Children.Add(myPolygon);
