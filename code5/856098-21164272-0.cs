    <DataGrid x:Name="grid" AutoGeneratingColumn="grid_AutoGeneratingColumn"/>
    private void grid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "ID":
                    e.Column.Header = "Customer ID";
                    break;
                case "CusName":
                    e.Column.Header = "Customer Name";
                    break;
                default:
                    break;
            }
        }
