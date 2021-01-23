    private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
    {
        Ellipse ellipse = new Ellipse()
        {
            Width = 64,
            Height = 64,
            Fill = new SolidColorBrush(Colors.Red),
            Opacity = 0.2,
            IsHitTestVisible = false,
        };
        Grid.SetColumnSpan(ellipse, 99);
        Grid.SetRowSpan(ellipse, 99);
        Point position = e.GetPosition((Grid)sender);
        ellipse.VerticalAlignment = VerticalAlignment.Top;
        ellipse.HorizontalAlignment = HorizontalAlignment.Left;
        ellipse.Margin = new Thickness(position.X - ellipse.Width / 2, position.Y - ellipse.Height / 2, 0, 0);
        ((Grid)sender).Children.Add(ellipse);
    }
