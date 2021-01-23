    //test is a stream here that I get using reflection
    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(test);
    DataSet result = excelReader.AsDataSet();
    while(excelReader.Read())
    {
        //process the file
    }
    excelReader.Close();
