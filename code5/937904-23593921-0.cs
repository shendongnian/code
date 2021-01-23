    privateToggleButton Toggle;
    public void ToggleButtonChecked(object sender, RoutedEventArgs e)
        {
            if (Toggle != null && Toggle != sender as ToggleButton)
            {
                Toggle.IsChecked = false;
            }
            Toggle = sender as ToggleButton;
        }
        public void ToggleButtonUnChecked(object sender, RoutedEventArgs e)
        {
            if (Toggle != null)
            {
                Toggle = null;
            }
        }
