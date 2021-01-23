    private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
    {
        SortGroupedDataGrid("Organization", sender, e);
    }
    private void SortGroupedDataGrid(string groupHeader, object sender, DataGridSortingEventArgs e)
    {
        var source = (sender as System.Windows.Controls.DataGrid).ItemsSource as ListCollectionView;
        if (source == null)
        {
            return;
        }
        e.Handled = true;
        var headerName = groupHeader;
        var column = e.Column;
        var isMainHeader = column.Header.ToString().Replace(" ", "").Equals(headerName);
        var mainSortDirection = ListSortDirection.Descending;
        var secondarySortDirection = ListSortDirection.Descending;
        if (isMainHeader)
        {
            mainSortDirection = column.SortDirection == ListSortDirection.Descending ?
                ListSortDirection.Ascending : mainSortDirection;
        }
        else
        {
            mainSortDirection = source.SortDescriptions[0].Direction;
            secondarySortDirection = column.SortDirection == ListSortDirection.Descending ?
                ListSortDirection.Ascending : secondarySortDirection;
        }
        using (source.DeferRefresh())
        {
            source.SortDescriptions.Clear();
            source.SortDescriptions.Add(new SortDescription(headerName, mainSortDirection));
            if (!isMainHeader)
            {
                source.SortDescriptions.Add(new SortDescription(column.Header.ToString().Replace(" ", ""), secondarySortDirection));
                column.SortDirection = secondarySortDirection;
            }
            else
            {
                column.SortDirection = mainSortDirection;
            }
        }
        source.Refresh();
    }
