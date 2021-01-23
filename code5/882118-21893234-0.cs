    private void Cont_OnChecked(object sender, RoutedEventArgs e)
    {
        if (Cf != null)
           Cf.IsEnabled = false;
    
    }
    
    private void Disc_OnChecked(object sender, RoutedEventArgs e)
    {
        if (Cf != null)
           Cf.IsEnabled = true;
    }
