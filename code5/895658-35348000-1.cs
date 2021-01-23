    //Method for Export Excel using Closed Xml
    public void ExportDataWithClosedXml_Method(DataTable table, string tabName, string fileType)
    {
    	var workbook = new XLWorkbook();
    	var ws = workbook.Worksheets.Add(table, tabName);
    	int row = 2 + table.Rows.Count;
    	int col = table.Columns.Count;
    	var redRow = ws.Row(1);
    	//redRow.Style.Fill.BackgroundColor = XLColor.Red;
    	redRow.InsertRowsAbove(1);
    	ws.Cell(1, 1).Value = "Name of Report Type";
    	ws.Cell(1, 1).Style.Font.Bold = true;
    	ws.Table(0).ShowAutoFilter = false;
    	//ws.Row(2).Style.Fill.BackgroundColor = XLColor.Red;
    	ws.Range(2, 1, 2, col).Style.Fill.BackgroundColor = XLColor.Green;
    	ws.Range(2, 1, 2, col).Style.Font.Bold = true;
    	ws.Range(3, 1, row, col).Style.Font.Italic = true;
    
    	HttpContext.Current.Response.Clear();
    	using (MemoryStream memoryStream = new MemoryStream())
    	{
    		workbook.SaveAs(memoryStream);
    		memoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
    		memoryStream.Close();
    	}
    	if (fileType == "xlsx")
    	{
    		HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    		HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=\"Samplefile.xlsx\"");
    	}
    	else
    	{
    		HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
    		HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=\"Samplefile.xls\"");
    	}
    	HttpContext.Current.Response.End();
    }
