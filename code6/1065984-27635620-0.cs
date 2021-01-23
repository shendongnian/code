    FileStream stream = File.Open(@"c:\working\test.xls", FileMode.Open, FileAccess.Read);
    
    IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
    
    excelReader.IsFirstRowAsColumnNames = true;
                
    DataSet result = excelReader.AsDataSet();
