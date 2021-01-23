    private void textToMask_TextChanged(object sender, TextChangedEventArgs e)  
    {  
        Typeface face = new Typeface("Candara");  
        FormattedText tx = new FormattedText(textToMask.Text, Thread.CurrentThread.CurrentUICulture, FlowDirection.LeftToRight, face, 70, Brushes.Black);  
        Geometry textGeom = tx.BuildGeometry(new Point(0, 0));  
        Rect boundingRect = new Rect(new Point(-100000, -100000), new Point(100000, 100000));  
        RectangleGeometry boundingGeom = new RectangleGeometry(boundingRect);  
        GeometryGroup group = new GeometryGroup();  
        group.Children.Add(boundingGeom);  
        group.Children.Add(textGeom);  
        target.Clip = group;  
    } 
