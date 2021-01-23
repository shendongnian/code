    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        Button clickedButton = e.OriginalSource as Button;
        if (clickedButton != null)
            NavigationService.Navigate(new Uri("/DataBoundApp1;component/MainPage.xaml?hdr=" + clickedButton.Content, UriKind.Relative));
    }
