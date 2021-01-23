    private void addGameButton_Click(object sender, RoutedEventArgs e)
    {
        BBCodeBlock bs = new BBCodeBlock();
        try
        {
            bs.LinkNavigator.Navigate(new Uri("/Pages/AddGame.xaml", UriKind.Relative), this);
        }
        catch (Exception error)
        {
            ModernDialog.ShowMessage(error.Message, FirstFloor.ModernUI.Resources.NavigationFailed, MessageBoxButton.OK);
        }
    }
