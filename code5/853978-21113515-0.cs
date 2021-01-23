    private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var canvas = (Canvas)sender;
        var startPoint = e.GetPosition(canvas);
        var line = new Line
        {
            Stroke = Brushes.Blue,
            StrokeThickness = 3,
            X1 = startPoint.X,
            Y1 = startPoint.Y,
            X2 = startPoint.X,
            Y2 = startPoint.Y,
        };
        canvas.Children.Add(line);
    }
    private void Canvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            var canvas = (Canvas)sender;
            var line = canvas.Children.OfType<Line>().Last();
            if (line != null)
            {
                var endPoint = e.GetPosition(canvas);
                line.X2 = endPoint.X;
                line.Y2 = endPoint.Y;
            }
        }
    }
