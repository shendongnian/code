    DataSet LoadDataSet()
    {
        using (Stream stream = File.OpenRead("MyExcelFile.xlsx"))
        {
            using (Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateOpenXmlReader(stream))
            {
                return excelReader.AsDataSet();
            }
        }
    }
