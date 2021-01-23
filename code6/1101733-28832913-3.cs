    private Image _imgSender;
    void Image_Loaded(object sender, RoutedEventArgs e)
    {
         _imgSender = sender as Image();
    }
    void AnotherMethod()
    {
          if (_imgSender != null)
             _imgSender.Visibility = Visibility.Collapsed;
    }
