    double[,] myArr = {{1,2},{3,4}};
    private void PopulateDataGrid()
    {
        DataTable dataTable = new DataTable();
        for (int j = 0; j < myArr.GetLength(1); j++)
            dataTable.Columns.Add(new DataColumn("Column " + j.ToString()));
        for (int i = 0; i < myArr.GetLength(0); i++)
        {
            var newRow = dataTable.NewRow();
            for (int j = 0; j < myArr.GetLength(1); j++)
                newRow["Column " + j.ToString()] = myArr[i, j];           
            dataTable.Rows.Add(newRow);
        }
        this.dataGrid1.ItemsSource = dataTable.DefaultView;
    }
