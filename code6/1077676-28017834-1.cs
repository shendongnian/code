        string paraName = "CONTROL";
        string fullPathToExcel = @"C:\Users\xbbjn2h\Desktop\Mapping.xlsx"; 
        string connString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""",fullPathToExcel);
        string sql = string.Format("SELECT [{0}],[{1}] from [{2}] WHERE [{0}] = ?", strFunction, strName, strSheetName);
        conn.ConnectionString = connString;
        using (OleDbConnection conn = new OleDbConnection())
        {
            OleDbCommand cmd = new OleDbCommand();
			cmd.Connection = conn;
			cmd.CommandText = sql;
			cmd.Parameter.Add("@Param1", OleDbType.VarChar).Value = paraName; // paraName or any value you wish.
			
            DataSet ds = new DataSet();
            conn.Open();
            OleDbDataAdapter dab = new OleDbDataAdapter(cmd); //or cmd.ExecuteNonQuery(); in Insert sql commands.
            dab.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }       
