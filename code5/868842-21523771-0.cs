    private void OnGotFocus(object sender, RoutedEventArgs e)
    {
        if (name.Text.Equals("Name", StringComparison.OrdinalIgnoreCase))
        {
            name.Text = string.Empty;
        }  
    }
