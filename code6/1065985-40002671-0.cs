    FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
    IExcelDataReader excelReader;
    
    //1. Reading Excel file
    if (Path.GetExtension(filePath).ToUpper() == ".XLS")
    {
        //1.1 Reading from a binary Excel file ('97-2003 format; *.xls)
        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
    }
    else
    {
        //1.2 Reading from a OpenXml Excel file (2007 format; *.xlsx)
        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
    }
    
    //2. DataSet - The result of each spreadsheet will be created in the result.Tables
    DataSet result = excelReader.AsDataSet();
    
    //3. DataSet - Create column names from first row
    excelReader.IsFirstRowAsColumnNames = false;
