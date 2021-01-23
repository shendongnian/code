    private void Panorama_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch(((Panorama)sender).SelectedIndex)
        {
             case 1:
                 ApplicationBar.IsVisible = true;
                 break;
             default:
                 ApplicationBar.IsVisible = false;
                 break;
        }
    }
