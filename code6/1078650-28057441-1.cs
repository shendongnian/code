    private void TextBox_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        tb.Background = new SolidColorBrush(Colors.Green);
    }
    private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
    {
        tb.Background = new SolidColorBrush(Colors.Green);
    }
    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        tb.Background = new SolidColorBrush(Colors.Blue);
    }
