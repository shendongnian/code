    private void chkSelectAll_Click(object sender, RoutedEventArgs e)
    {
        var visible = chkSelectAll.IsChecked ?? false;
        foreach (var column in reportGrid.Columns)
            column.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;      
    }
