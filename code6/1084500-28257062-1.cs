    private void toggle_Checked(object sender, RoutedEventArgs e)
    {
      foreach (var control in container.Children)
        (control as RadioButton).IsEnabled = false;
    }
    
    private void toggle_Unchecked(object sender, RoutedEventArgs e)
    {
      foreach (var control in container.Children)
        (control as RadioButton).IsEnabled = true;
    }
