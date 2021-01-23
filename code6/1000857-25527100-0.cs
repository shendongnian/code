    var dataTable = dataBase.FetchData(runDate.ToShortDateString());
    DataTable fitleredDataTable = dataTable.Select("(col != 'blah blah')").CopyToDataTable();
    
    var application = new Application();
    var workbook = application.Workbooks.Add();
    var worksheet = (Worksheet)workbook.Sheets[1];
    var columns = fitleredDataTable.Columns.Count;
    var rows = fitleredDataTable.Rows.Count;
        
    var range = worksheet.Range["A2", String.Format("{0}{1}", GetExcelColumnName(columns), rows)];
        
    var data = new object[rows, columns];
    
    for (int i = 1; i < fitleredDataTable.Columns.Count; i++)
    {
    	worksheet.Cells[1, i] = fitleredDataTable.Columns[i - 1].ColumnName;
    }
    for (int rowNumber = 0; rowNumber < rows; rowNumber++)
    {
    	for (int columnNumber = 0; columnNumber < columns; columnNumber++)
    	{
    		data[rowNumber, columnNumber] = fitleredDataTable.Rows[rowNumber][columnNumber].ToString();
    	}
    }
    range.Value = data;
