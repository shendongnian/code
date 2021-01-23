    using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
    {
    	using (IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream, true))
    	{
    		excelReader.IsFirstRowAsColumnNames = true;
    		var excelFileDataSet = excelReader.AsDataSet();
    		var sheetDataTable = excelFileDataSet.Tables["sheetName"];
    		//other file processing code...
    	}
    }    
