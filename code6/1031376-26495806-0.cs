     private void btnGoBack_Click(object sender, RoutedEventArgs e)
     {
        // <<<<< Creates new page >>>>>>>>
        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
     }
