    private void SetRowErrors(DataTable table)
    {
        for(int i = 0; i < 10; i++)
        {
            table.Rows[i].RowError = "ERROR: " 
                + table.Rows[i][1];
        }
        DataSet dataSet = table.DataSet;
        TestForErrors(dataSet);
    }
    
    private void TestForErrors(DataSet dataSet)
    {
        if(dataSet.HasErrors)
        {
            foreach(DataTable tempDataTable in dataSet.Tables)
            {
                if(tempDataTable.HasErrors) 
                    PrintRowErrors(tempDataTable);
            }
            dataGrid1.Refresh();
        }
    }
    
    private void PrintRowErrors(DataTable table)
    {
        foreach(DataRow row in table.Rows)
        {
            if(row.HasErrors) 
            {
                Console.WriteLine(row.RowError);
            }
        }
    }
