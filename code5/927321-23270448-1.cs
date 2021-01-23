    private void KittyPic_Tapped(object sender, TappedRoutedEventArgs e)
    {
        LoadingPanel.Visibility = Visibility.Visible;
        Uri myUri = new Uri("http://thecatapi.com/api/images/get?format=src&type=jpg", UriKind.Absolute);
        BitmapImage bmi = new BitmapImage();
        bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
        bmi.UriSource = myUri;
        KittyPic.Source = bmi;
    }
    
    private void KittyPic_ImageOpened(object sender, RoutedEventArgs e)
    {
        LoadingPanel.Visibility = Visibility.Collapsed;
    }
    
    private async void KittyPic_ImageFailed(object sender, ExceptionRoutedEventArgs e)
    {
        LoadingPanel.Visibility = Visibility.Collapsed;
        await new MessageDialog("Failed to load the image").ShowAsync();
    }
