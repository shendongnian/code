    var anImage = new Image
    {
        Width = 120,
        Height = 310,
        HorizontalAlignment = HorizontalAlignment.Left,
        VerticalAlignment = VerticalAlignment.Top,
        Margin = new Thickness(500, 500, 0, 0),
        Source = new BitmapImage(new Uri("pack://application:,,,/Images/balloonB.png"))
    };
    rootGrid.Children.Add(anImage);
