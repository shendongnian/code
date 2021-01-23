    private void DataGrid_AutoGeneratingColumn(object sender, 
                                        DataGridAutoGeneratingColumnEventArgs e)
    {
       e.Column.Header = e.Column.Header.ToString().Replace("_", "__");
    }
