    private void MessageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (MessageList.SelectedItem == null)
        {
            return;
        }
        Contact c = (Contact)MessageList.SelectedItem;
        long id = c.ID;
        NavigationService.Navigate(new Uri("/ChatPage.xaml?ID=" + id.ToString(), UriKind.Relative));
    }
