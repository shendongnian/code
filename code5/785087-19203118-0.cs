    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        ApplicationBarIconButton btn= ApplicationBar.Buttons[0] as ApplicationBarIconButton;
        if (btn!= null)
        {
            btn.Text = AppResources.Test;
        }
        
    }
