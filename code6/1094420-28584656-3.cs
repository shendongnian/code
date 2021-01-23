    private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
    {
        Ellipse ellipse = new Ellipse()
        {
            Width = 64,
            Height = 64,
            Fill = new SolidColorBrush(Colors.Red),
            Opacity = 0.2,
            IsHitTestVisible = false, // This makes the circle transparent for touch, so you can tap things under it.
        };
        Grid.SetColumnSpan(ellipse, 99); // You need this if you have more columns than one.
        Grid.SetRowSpan(ellipse, 99); // You need this if you have more rows than one.
        Point position = e.GetPosition((Grid)sender);
        ellipse.VerticalAlignment = VerticalAlignment.Top; // This will allow us to use top margin as Y coordinate.
        ellipse.HorizontalAlignment = HorizontalAlignment.Left; // This will allow us to use left margin as X coordinate.
        ellipse.Margin = new Thickness(position.X - ellipse.Width / 2, position.Y - ellipse.Height / 2, 0, 0); // Place the circle where user taps.
        ((Grid)sender).Children.Add(ellipse);
    }
