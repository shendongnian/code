    const int lastN = 21;
    int[] minutesMax = { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 ,21};
    int[] minutesMin = { 6, 7, 8, 9, 10, 6, 7, 8, 9, 10, 6, 7, 8, 9, 10, 6, 7, 8, 9, 10 ,22};
    DataTable dataTable;
    private void SetBinding()
    {
        dataTable = new DataTable();
        for (int i = 0; i < lastN; i++)
        {
            dataTable.Columns.Add();
        }
        dataTable.Rows.Add(dataTable.NewRow());
        dataTable.Rows.Add(dataTable.NewRow());
        for (int i = 0; i < lastN; i++)
        {
            dataTable.Rows[0][i] = minutesMax[i];
            dataTable.Rows[1][i] = minutesMin[i];
        }
            
        dataGridView3.DataSource = dataTable;
    }
