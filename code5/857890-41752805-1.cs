    ObservableCollection<cListEntry> itemsToRemove = new ObservableCollection<cListEntry>();
    foreach (cListEntry item in MyList.SelectedItems)
    {
        itemsToRemove.Add(item);
    }
    foreach (cListEntry item in itemsToRemove)
    {
        ((ObservableCollection<cListEntry>)MyList.ItemsSource).Remove(item);
    }
