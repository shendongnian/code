    var x = 0;
    var y = 0;
    var n = 0;
    while (n < 1000)
    {
        x = x + 20;
        if (x > 600)
        {
            x = 0;
            y = y + 20;
        }
        var myLineGeometry = new LineGeometry
        {
            StartPoint = new Point(x, y),
            EndPoint = new Point(x, y + 15)
        };
    
        MyGroup.Children.Add(myLineGeometry);
        n++;
    }
                
    MyPath.Stroke = Brushes.White;
    MyPath.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
    MyPath.Data = MyGroup;
