    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
          LayoutRoot.Margin = new Thickness(0, 0, 0, 0);
          LayoutRoot.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
    }
