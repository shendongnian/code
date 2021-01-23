    string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; data source={path of your excel file}; Extended Properties=Excel 12.0;";
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            //Create connection object by using the preceding connection string.
            objConn = new OleDbConnection(connString);
            objConn.Open();
            //Get the data table containg the schema guid.
            dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sql = string.Format("select * from [{0}$]", sheetName);
            var adapter = new System.Data.OleDb.OleDbDataAdapter(sql, ConnectionString);
            var ds = new System.Data.DataSet();
            string tableName = sheetName;
            adapter.Fill(ds, tableName);
            System.Data.DataTable data = ds.Tables[tableName];
