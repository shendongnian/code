    string propertyName = "DateOfEnquiry";
    
    ICollectionView dataView = CollectionViewSource.GetDefaultView(lstvwDetails.ItemsSource);
    ListSortDirection direction = ListSortDirection.Ascending;
    
    if (dataView.SortDescriptions.Count > 0 && dataView.SortDescriptions[0].PropertyName == propertyName)
    {
        if (dataView.SortDescriptions[0].Direction == ListSortDirection.Ascending) direction = ListSortDirection.Descending;
        else direction = ListSortDirection.Ascending;
    }
    dataView.SortDescriptions.Clear();
    dataView.SortDescriptions.Add(new SortDescription(propertyName, direction));
