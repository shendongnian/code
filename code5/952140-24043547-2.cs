    var anImage = new Image();
    anImage.Width = 120;
    anImage.Height = 310;
    anImage.HorizontalAlignment = HorizontalAlignment.Left;
    anImage.VerticalAlignment = VerticalAlignment.Top;
    anImage.Margin = new Thickness(500, 500, 0, 0);
    anImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/balloonB.png"));
    rootGrid.Children.Add(anImage);
