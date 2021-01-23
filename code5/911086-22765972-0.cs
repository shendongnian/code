    string Path = @"E:\\DemoXls.xls";
            var con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= '" + Path + "';Extended Properties=" + (char)34 + "Excel 8.0;IMEX=1;" + (char)34 + "");
            
            con.Open();
            DataTable mySheets = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            con.Close();
            
            var dt = new DataTable();
            var da = new OleDbDataAdapter();
            da.SelectCommand = new OleDbCommand();
            da.SelectCommand.Connection = con;
            var query = "Select * from [{0}]";
            foreach (DataRow item in mySheets.Rows)
            {
                da.SelectCommand.CommandText = string.Format(query, item["TABLE_NAME"].ToString());
                da.Fill(dt);
                //DO the mapping of DataTable to your List<T>   
            }
