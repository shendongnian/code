    private void rectControl_PointerPressed( object sender , PointerRoutedEventArgs e )
    {
        rectControl.Fill = new SolidColorBrush(Colors.Blue);
    }
    private void rectControl_PointerReleased( object sender , PointerRoutedEventArgs e )
    {
        rectControl.Fill = new SolidColorBrush(Colors.White);
    }
