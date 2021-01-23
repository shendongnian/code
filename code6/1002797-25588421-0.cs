    // hook for when exporting is done.
    reportViewer.ReportExport += reportViewer_ReportExport;
	void reportViewer_ReportExport(object sender, ReportExportEventArgs e)
	{
		// Prepare an Export path for the user's desktop
		exportPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
				+ "\\SomeExportPath\\";
		// In case multiple exports, time-stamp the file name too
		timeMark = DateTime.Now.ToString("yyyyMMddTHHmmss");
		if (sender != null )
		{
			switch( e.Extension.Name )
			{
				case "Excel":
					ExportForExcel();
					e.Cancel = true;
					Messagebox( "Exported Excel(CSV) to your desktop in the \r\n"
							+ "folder 'SomeExportPath\\SomeFile.csv'" ); 
					break;
			}
		}
	}
	protected virtual void ExportForExcel()
	{}
	protected void TableToCSV( DataTable dt, string FinalFileName )
	{
		StringBuilder sb = new StringBuilder(); 
		IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
		sb.AppendLine(string.Join(",", columnNames));
		foreach (DataRow row in dt.Rows)
		{
			IEnumerable<string> fields = row.ItemArray.Select(field => 
			  string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
			sb.AppendLine(string.Join(",", fields));
		}
		File.WriteAllText(exportPath + FinalFileName + ".csv", sb.ToString());
	}
