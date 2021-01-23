    private void userTapped(object sender, TappedRoutedEventArgs e)
    {
        var selectedItem = lbMessagesUsersList.SelectedItem;
        var subject = MyDatasMessagesUserList.FirstOrDefault(sub => sub == selectedItem);
    }
