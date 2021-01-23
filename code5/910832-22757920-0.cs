    private void dataGrid_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (var column in ((DataGrid)sender).Columns)
        {
            column.Width = new DataGridLength(column.ActualWidth + 30);
        }
    }
