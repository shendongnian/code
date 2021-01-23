    private static void Main(string[] args)
    {
        var dataT = Import(@"C:\Users\jlambert\Desktop\dSmall_encrypted.xlsx");
        var data = dataT.AsEnumerable();
    ...
    }
	public static System.Data.DataTable Import(String path)
	{
		var app = new Application();
		Workbook workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
		Worksheet workSheet = (Worksheet)workBook.ActiveSheet;
		int index = 0;
		object rowIndex = 2;
		System.Data.DataTable dt = new System.Data.DataTable();
		dt.Columns.Add("Facility_code"); 					
		dt.Columns.Add("MRN");
		dt.Columns.Add("first_name");
		dt.Columns.Add("middle_name");
		dt.Columns.Add("last_name");
		dt.Columns.Add("address_line_1");
		dt.Columns.Add("address_line_2");
		dt.Columns.Add("city");
		dt.Columns.Add("state");
		dt.Columns.Add("zip");
		dt.Columns.Add("date_of_birth");
		dt.Columns.Add("gender");
		dt.Columns.Add("ssn");
		dt.Columns.Add("home_phone");
		dt.Columns.Add("work_phone");
		dt.Columns.Add("cell_phone");
		dt.Columns.Add("PCP");
		dt.Columns.Add("Practice Location");
		DataRow row;
		while (((Range)workSheet.Cells[rowIndex, 1]).Value2 != null)
		{
			rowIndex = 2 + index;
			row = dt.NewRow();
			row[0] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 1]).Value2);
			row[1] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 2]).Value2);
			row[2] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 3]).Value2);
			row[3] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 4]).Value2);
			row[4] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 5]).Value2);
			row[5] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 6]).Value2);
			row[6] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 7]).Value2);
			row[7] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 8]).Value2);
			row[8] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 9]).Value2);
			row[9] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 10]).Value2);
			row[10] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 11]).Value2);
			row[11] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 12]).Value2);
			row[12] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 13]).Value2);
			row[13] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 14]).Value2);
			row[14] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 15]).Value2);
			row[15] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 16]).Value2);
			row[16] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 17]).Value2);
			row[17] = Convert.ToString(((Range)workSheet.Cells[rowIndex, 18]).Value2);
			index++;
			dt.Rows.Add(row);
		}
		app.Workbooks.Close();
		return dt;
	}
