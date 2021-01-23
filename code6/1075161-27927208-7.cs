    private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "YourProperty")
        {
            e.Column.Visibility = Visibility.Collapsed;
        }
    }
