    private void DrawMapMarker(GeoCoordinate coordinate, Color color, MapLayer mapLayer)
    {
        var content = new Grid();
        Polygon polygon = new Polygon();
        polygon.Points.Add(new Point(0, 0));
        polygon.Points.Add(new Point(0, 75));
        polygon.Points.Add(new Point(25, 0));
        polygon.Fill = new SolidColorBrush(color);
        var text = new TextBlock 
        { 
            Text = "HIIIIIII",
            Foreground = new SolidColorBrush(Colors.Orange),
        };
        var viewbox = new Viewbox { Child = text };
        content.Children.Add(polygon);
        content.Children.Add(viewbox);
        // Enable marker to be tapped for location information
        polygon.Tag = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
        polygon.MouseLeftButtonUp += polygon_MouseLeftButtonUp;
        // Create a MapOverlay and add marker.
        MapOverlay overlay = new MapOverlay();
        overlay.Content = content;
        overlay.GeoCoordinate = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
        overlay.PositionOrigin = new Point(0.0, 1.0);
        mapLayer.Add(overlay);
    }
