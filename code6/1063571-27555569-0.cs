    // consider this:
    // ObservableCollection<...> myCollection = ...
    // then
    var view = CollectionViewSource.GetDefaultView(myCollection);
    view.GroupDescriptions.Add(new PropertyGroupDescription("Group1"));
    view.SortDescriptions.Add(new SortDescription("Group1", ListSortDirection.Ascending));
    MyDataGrid.ItemsSource = myCollection;
