    private void SettingsButtonClicked(object sender, RoutedEventArgs e)
    {
        settingsButton.ContextMenu.Visibility = Visibility.Visible;
        settingsButton.ContextMenu.PlacementTarget = sender as Button;
        settingsButton.ContextMenu.IsOpen = true;
    }
