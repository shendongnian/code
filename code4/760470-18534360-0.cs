        private DataSet ConnectAndLoad(string filepath, string sheet)
        {
            DataSet data_set = new DataSet();
            OleDbConnection oledbConn = new OleDbConnection(String.Format("Provider=Microsoft.Ace.Oledb.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1;\"", filepath));
            string query = "Select * From [" + sheet + "$]";
            try
            {
                oledbConn.Open();
                OleDbCommand oledbCmd = new OleDbCommand(query, oledbConn);
                OleDbDataAdapter ole_da = new OleDbDataAdapter(oledbCmd);
                ole_da.Fill(data_set);
            }
            catch (OleDbException ex)
            {
                // do some error catching
            }
            finally
            {
                oledbConn.Close();
            }
            return data_set;
        }
