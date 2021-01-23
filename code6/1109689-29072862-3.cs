        private void OnChecked(object sender, RoutedEventArgs e)
              {
                 _checked.Add((CheckBox)sender);
              }
    private void OnUnchecked(object sender, RoutedEventArgs e)
              {
                 _checked.Remove((CheckBox)sender);
              }
