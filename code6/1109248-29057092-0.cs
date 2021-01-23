    private void Canvas_Tapped(object sender, TappedRoutedEventArgs e)
    {
        var point = e.GetPosition(Canvas1);
        //example shape
        const double width = 30d;
        const double height = 30d;
        var ellipse = new Ellipse
        {
            Width = width,
            Height = height,
            Fill = new SolidColorBrush(Colors.Red),
            RenderTransform = new TranslateTransform
            {
                X = point.X - width/2,
                Y = point.Y - height/2
            }
        };
        Canvas1.Children.Add(ellipse);
    }
