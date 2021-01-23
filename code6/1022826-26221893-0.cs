    IExcelDataReader excelReader;
    
    if (String.Compare(extension, ".xls", true) == 0){
        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
    } else if (String.Compare(extension , ".xlsx", true) == 0){
        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
    }
    
    excelReader.IsFirstRowAsColumnNames = true;
    result = excelReader.AsDataSet();
