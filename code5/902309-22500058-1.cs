    private void longlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string selectedItem = String.Empty;
        if (e.AddedItems.Count > 0) selectedItem = e.AddedItems[0] as string;
        else selectedItem = e.RemovedItems[0] as string;
        MessageBox.Show(selectedItem); // do your work
    }
