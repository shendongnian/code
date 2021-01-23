    Image anImage = new Image();
    anImage.Visibility = Visibility.Visible;
    anImage.Width = 120;
    anImage.Height = 310;
    anImage.HorizontalAlignment = HorizontalAlignment.Left;
    anImage.VerticalAlignment = VerticalAlignment.Top;
    //anImage.Margin = new Thickness(500, 500, 0, 0);
    BitmapImage bmImage = new BitmapImage();
    bmImage.BeginInit();
    bmImage.UriSource = new Uri("balloonB.png", UriKind.Relative);
    bmImage.EndInit();
    
    ImageBrush ib = new ImageBrush(bmImage);
    anImage.Source = ib.ImageSource;
    gr.Children.Add(anImage);
