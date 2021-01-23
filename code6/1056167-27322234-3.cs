	using (ExcelPackage pck = new ExcelPackage())
	{
		var ws = pck.Workbook.Worksheets.Add("Demo");
		ws.Cells[1, 2].Value = "Excel Test";
		
		var fileBytes = pck.GetAsByteArray();
		Response.Clear();
		Response.AppendHeader("Content-Length", fileBytes.Length.ToString());
		Response.AppendHeader("Content-Disposition",
			String.Format("attachment; filename=\"{0}\"; size={1}; creation-date={2}; modification-date={2}; read-date={2}"
				, "temp.xlsx"
				, fileBytes.Length
				, DateTime.Now.ToString("R"))
			);
		Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
		Response.BinaryWrite(fileBytes);
		Response.End();
	}
