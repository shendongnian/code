    BitmapImage bmp;
    bmp = new BitmapImage(new Uri (this.BaseUri, "/Assets/zombie.png"));
    newGaston.Image.Source = bmp;
    newGaston.Image.Tapped += GastonTapped;
    ....
    private void GastonTapped(object sender, TappedRoutedEventArgs e)
    {
    // remove the zombie.
    }
