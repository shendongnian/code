    private DataTable WorksheetToDataTable(ExcelWorksheet oSheet)
    {
	int totalRows = oSheet.Dimension.End.Row;
	int totalCols = oSheet.Dimension.End.Column;
	DataTable dt = new DataTable(oSheet.Name);
	DataRow dr = null;
	for (int i = 1; i <= totalRows; i++)
	{
		if (i > 1) dr = dt.Rows.Add();
		for (int j = 1; j <= totalCols; j++)
		{
			if (i == 1)
				dt.Columns.Add(oSheet.Cells[i, j].Value.ToString());
			else
				dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
		}
	}
	return dt;
