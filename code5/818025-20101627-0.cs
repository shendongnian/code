        using System.Data.OleDb;
        public bool ValidateExcelFile(string fileName)
        {
            string connString = string.Format("Provider=Microsoft.Jet.OleDb.4.0; data source={0}; Extended Properties=\"Excel 8.0;HDR=Yes\"", fileName);
            OleDbConnection connection = null;
            try
            {
                connection = new OleDbConnection(connString);
                connection.Open();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
