    int i = 1;
    int j = 1;   
    //header row
    foreach(var col in dtMainSQLData.Columns)
    {  
	  ExcelApp.Cells[i, j]  = col.ColumnName;
	  j++;
    }
 
    i++;
    //data rows
    foreach(var row  in dtMainSQLData.Rows)
    {
        for (int k = 1; k < dtMainSQLData.Columns.Count + 1; k++)
        {
	         ExcelApp.Cells[i, k]  = row[k-1].ToString();
        }
        i++;
    }
