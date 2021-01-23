    public void UpdateItemsSource()
    {
        IdentifySelectedError(); //get "selectedRowIndex"
        using (var context = new Context())
        {
            DataGrid.ItemsSource = context.Error.Take(100).ToList();
        }
        MainDataGrid.SelectedItem = MainDataGrid.Items[indexOfRow];
        MainDataGrid.ScrollIntoView(MainDataGrid.Items[indexOfRow]);
    }
