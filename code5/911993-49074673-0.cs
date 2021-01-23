    for (int i = 1; i < dtMainSQLData.Rows.Count + 1; i++)
    {
    	for (int j = 1; j < dtMainSQLData.Columns.Count + 1; j++)
    	{
    		if (i == 1)
    			ExcelApp.Cells[i, j] = dcCollection[j - 1].ToString();
                
    		ExcelApp.Cells[i + 1, j] = dtMainSQLData.Rows[i - 1][j - 1].ToString();
    	}
    }
