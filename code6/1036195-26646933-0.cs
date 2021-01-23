    private void ServiceListView_Loaded(object sender, RoutedEventArgs e) {
        CollectionView view = new CollectionView(this.ServiceListView.ItemsSource);
        view.Filter = ServiceFilter;
        //use the created view here such as by assigning it to some ItemsSource
        //...
    }
