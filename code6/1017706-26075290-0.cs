    private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var panel = (Panel)sender;
        var polyline = new Polyline
        {
            Stroke = Brushes.Black,
            StrokeThickness = 3
        };
        panel.Children.Add(polyline);
        panel.CaptureMouse();
    }
    private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ((UIElement)sender).ReleaseMouseCapture();            
    }
    private void CanvasMouseMove(object sender, MouseEventArgs e)
    {
        var panel = (Panel)sender;
        if (panel.IsMouseCaptured)
        {
            var polyline = panel.Children.OfType<Polyline>().Last();
            polyline.Points.Add(e.GetPosition(panel));
        }
    }
