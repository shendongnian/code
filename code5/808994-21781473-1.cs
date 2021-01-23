    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        polyline.Points.Add(new Point(0,0));
        polyline.Points.Add(new Point(0, 1));
        polyline.Points.Add(new Point(1, 0));
        polyline.Points.Add(new Point(1, 1));
    }
