    private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
    {
        SortGroupedDataGrid("Organization", sender, e);
    }
    private void SortGroupedDataGrid(string groupHeader, object sender, DataGridSortingEventArgs e)
    {
        // Get the main ListCollectionView and make sure it's not null.
        var source = (sender as System.Windows.Controls.DataGrid).ItemsSource as ListCollectionView;
        if (source == null)
        {
            return;
        }
        // Mark event as handled, so that automated sorting would not take place.
        e.Handled = true;
        // Main header which was used for the grouping.  I'm only using one, but more can be added.
        var headerName = groupHeader;
        // Get the column that was being sorted on.
        var column = e.Column;
        // Check if the column was the same as the one being used for the grouping.
        // I remove spaces so that any properties I use match the headers.  Regex would probably
        // work just as well, but it's an overkill for me at this time.
        var isMainHeader = column.Header.ToString().Replace(" ", "").Equals(headerName);
        // Because I set the initial sorting for all the properties in the XAML to be
        // be sorted in Ascending order, I set these ones to Descending.  One is for
        // the main column and the other is for the secondary column.  This does not account
        // for a case where user Shift + Clicks multiple columns to chain sort.
        var mainSortDirection = ListSortDirection.Descending;
        var secondarySortDirection = ListSortDirection.Descending;
        // If this is a main column sort event...
        if (isMainHeader)
        {
            // Check its sorting direction and set it as opposite.
            mainSortDirection = column.SortDirection == ListSortDirection.Descending ?
                ListSortDirection.Ascending : mainSortDirection;
        }
        else
        {
            // ...else, get the sorting direction of the main column, because we want
            // it to stay the same, and get the opposite sorting direction for the
            // secondary column.
            mainSortDirection = source.SortDescriptions[0].Direction;
            secondarySortDirection = column.SortDirection == ListSortDirection.Descending ?
                ListSortDirection.Ascending : secondarySortDirection;
        }
        // Defer refreshing of the DataGrid.
        using (source.DeferRefresh())
        {
            // Clear any existing sorts.  I've had some issues trying to alter existing ones.
            source.SortDescriptions.Clear();
            // Since we want main column to either alter if its sort event was called, or
            // stay the same if secondary column event was called, we always set it first.
            source.SortDescriptions.Add(new SortDescription(headerName, mainSortDirection));
            // If this was not a main column event...
            if (!isMainHeader)
            {
                // ...then set sorting for that other column. Since it'll be at index 1, 
                // after the main one, it'll only sort within each group, as I wanted.
                source.SortDescriptions.Add(new SortDescription(column.Header.ToString().Replace(" ", ""), secondarySortDirection));
                // Set the header direction as well.
                column.SortDirection = secondarySortDirection;
            }
            else
            {
                // Otherwise, it's a main event and we want to show the error for its header.
                // If you want primary sorting direction to always display, then simply take
                // it outside of else scope, so that it's always assigned.
                column.SortDirection = mainSortDirection;
            }
        }
        // Now we can refresh and post changes.
        source.Refresh();
    }
