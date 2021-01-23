	public ReturnValue reflexTime(string cesta )
    {
		ReturnValue output = new ReturnValue();
	
        // LOAD XLS to ARRAY
        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(cesta);
        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        Excel.Range xlRange = xlWorksheet.UsedRange;
        int rowCount = xlRange.Rows.Count;
        int colCount = xlRange.Columns.Count;
        output.Array = new string[rowCount, colCount];
        for (int i = 1; i <= rowCount; i++)
        {
            for (int j = 1; j <= colCount; j++)
            {
                string str = xlRange.Cells[i, j].Text;
                output.Array[i - 1, j - 1] = str;
            }
            output.Percent = ((100 * i) / rowCount);
        }
        MessageBox.Show("Súbor načítaný");
		return output;
    }
