        var stream = new MemoryStream();
        
    // print header
    using (var package = new ExcelPackage(stream))
    {
    	// add a new worksheet to the empty workbook
    	var worksheet = package.Workbook.Worksheets.Add("testsheet");
    	for(var i = 0; i < 10; i++)
    		worksheet.Cells[i + 1, 1].Value = i.ToString();
    
    	worksheet.Cells["A1:A3"].Merge = true;
    	worksheet.Cells["A1:A3"].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
    	worksheet.Cells["A1:A3"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
    	worksheet.Cells["A1:A3"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
    	worksheet.Cells["A1:A3"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
    	worksheet.Cells["A1:A3"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
    	worksheet.Cells["A1:A3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
    	worksheet.Cells["A1:A3"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#f0f3f5"));
    
    	 package.Save();
    }
    
    stream.Seek(0, SeekOrigin.Begin);
    
    using (Stream file = File.Open("sample.xlsx", FileMode.Create))
    {
    	var buffer = new byte[8 * 1024];
    	int len;
    	while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
    		file.Write(buffer, 0, len);
    }
