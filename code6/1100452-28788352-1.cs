    private void TurnLeftButton_Click(object sender, RoutedEventArgs e)
    {
        var biOriginal = (BitmapImage) Image1.Source;
        var biRotated = new BitmapImage();
        biRotated.BeginInit();
        biRotated.UriSource = biOriginal.UriSource;
        biRotated.Rotation = Rotation.Rotate270;
        biRotated.EndInit();
        Image1.Source = biRotated;
    }
