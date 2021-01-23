    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
         LayoutRoot.Margin = new Thickness(0, 330, 0, 0);
         LayoutRoot.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
    }
