    private void hotNo(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Is it currently 2-5 PM?",
                "Time", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                NavigationService.Navigate(new Uri("/TacoBell.xaml", UriKind.Relative));
            }
            else if (result == MessageBoxResult.Cancel)
            {
                NavigationService.Navigate(new Uri("/Pizza.xaml", UriKind.Relative));
            }
        }
