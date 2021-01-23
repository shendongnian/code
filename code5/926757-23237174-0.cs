    private void list_Selected(object sender, RoutedEventArgs e)
    {
        var eModel = (EventModel)((ListView)sender).SelectedItem;
    
        var targets = GetEndPointTypesFromList(eModel);
        listview.ItemsSource = targets;
                
    }
