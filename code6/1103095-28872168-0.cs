    public class ExcelReader
    {
        public static DataSet ReadExcel(string excelFilePath, string workSheetName)
        {
            DataSet dsWorkbook = new DataSet();
            string connectionString = string.Empty;
            switch (Path.GetExtension(excelFilePath).ToUpperInvariant())
            {
                case ".XLS":
                    connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties=Excel 8.0;", excelFilePath);
                    break;
                case ".XLSX":
                    connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;", excelFilePath);
                    break;
                
            }
            if (!String.IsNullOrEmpty(connectionString))
            {
                string selectStatement = string.Format("SELECT * FROM [{0}$]", workSheetName);
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectStatement, connectionString))
                {                   
                    adapter.Fill(dsWorkbook, workSheetName);  
                }
            }
            return dsWorkbook;
        }
    }
