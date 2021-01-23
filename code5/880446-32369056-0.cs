            DataTable DT = new DataTable(); 
            FileStream stream = File.Open(Filepath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet result = excelReader.AsDataSet();
            excelReader.Close();
            DT = result.Tables[0];
