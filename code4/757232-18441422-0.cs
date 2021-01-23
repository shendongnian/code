    public void ServerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var current = ServerList.SelectedItem as readqueriesObject;
        if (current != null)
        {
            NavigationService.Navigate(new Uri("/singlequery.xaml?selectedItem=" +current.Query_Id , UriKind.Relative));
            // Reset selected index to -1 (no selection)
            ServerList.SelectedIndex = -1;
        }
    }
