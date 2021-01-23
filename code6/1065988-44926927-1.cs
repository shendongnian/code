    FileStream stream = File.Open(@"C:\Users\Desktop\ExcelDataReader.xlsx", FileMode.Open, FileAccess.Read);
    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
    DataSet result = excelReader.AsDataSet();
    excelReader.IsFirstRowAsColumnNames = true;         
    DataTable dt = result.Tables[0];
    string text = dt.Rows[1][0].ToString();
