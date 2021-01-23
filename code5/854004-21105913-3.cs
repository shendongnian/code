    OleDbConnection theConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Projects\Demo\Demo.xls;Extended Properties=Excel 8.0;");
            theConnection.Open();
            OleDbCommand theCmd = new OleDbCommand("SELECT * FROM [Sheet1$]", theConnection);
            OleDbDataAdapter theDataAdapter = new OleDbDataAdapter(theCmd);
            DataSet DS = new DataSet();
            theDataAdapter.Fill(DS);
            theConnection.Close();
