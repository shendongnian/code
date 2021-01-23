    string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + **EXCEL FILE PATH** + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            
            OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM [**HEADER HERE** $]", conn);
            cmd2.CommandType = CommandType.Text;
            DataTable outputTable2 = new DataTable("myDataTable");
            new OleDbDataAdapter(cmd2).Fill(outputTable2);
