    yourObservableCollection.CollectionChanged +=
    (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs args) =>
    {
        if (sender is System.Windows.Controls.DataGrid)
        {
            ...
        }
    }
