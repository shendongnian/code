    private void TurnLeftButton_Click(object sender, RoutedEventArgs e)
    {
        var biOriginal = new BitmapImage(new Uri("Images/logo.png", UriKind.Relative));
        Image1.Source = biOriginal; 
        var biRotated = new BitmapImage();
        biRotated.BeginInit();
        biRotated.UriSource = biOriginal.UriSource;
        biRotated.Rotation = Rotation.Rotate270;
        biRotated.EndInit();
        Image1.Source = biRotated;
    }
