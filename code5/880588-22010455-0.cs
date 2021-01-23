Provider=Microsoft.ACE.OLEDB.12.0;Data Source='filename.xlsx';Extended Properties='Excel 12.0;HDR=No;IMEX=0;ImportMixedTypes=Text;TypeGuessRows=0'
    string connHeaders = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties='Excel 12.0;HDR=No;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0'";
    string connData = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties='Excel 12.0;HDR=No;IMEX=0;ImportMixedTypes=Text;TypeGuessRows=0'";
    int dataStartRow = 0;
    string tablename = "";
    #region Open file to find headers
    using (OleDbConnection objConn = new OleDbConnection(connHeaders))
    {
        objConn.Open();
        var exceltables = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });
        tablename = exceltables.Rows[0]["TABLE_NAME"].ToString();
        using (OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [" + tablename + "] ", objConn))
        {
            using (OleDbDataReader reader = objCmdSelect.ExecuteReader())
            {
                while (reader.Read())
                {
					if (reader[0].ToString().ToLower() == "upc")
					{
						for (int i = 0; i < reader.FieldCount; i++)
						{
							//find all necessary headers
						}
						break;
					}
					dataStartRow++;
                }
            }
        }
    }
    #endregion
    #region Open file again to read data
    using (OleDbConnection objConn = new OleDbConnection(connData))
    {
        objConn.Open();
        using (OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [" + tablename + "] ", objConn))
        {
            using (OleDbDataReader reader = objCmdSelect.ExecuteReader())
            {
                for (int i = 0; i < dataStartRow; i++) reader.Read();
                while (reader.Read())
                {
					//read the line to save it in Database
                }
            }
        }
    }
