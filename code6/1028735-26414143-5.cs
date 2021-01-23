    private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
    {
        var headerName = "Organization";
        var column = e.Column;
        if (!column.Header.ToString().Equals(headerName))
        {
            return;
        }
        var source = (sender as System.Windows.Controls.DataGrid).ItemsSource as ListCollectionView;
        if (source == null)
        {
            return;
        }
        e.Handled = true;
        var sortDirection = column.SortDirection == ListSortDirection.Ascending ? 
            ListSortDirection.Descending : ListSortDirection.Ascending;
        using (source.DeferRefresh())
        {
            source.SortDescriptions.Clear();
            source.SortDescriptions.Add(new SortDescription(headerName, sortDirection));
        }
        source.Refresh();
        column.SortDirection = sortDirection;
    }
