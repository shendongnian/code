           string path = @"C:\Extract\Extract.xlsx";
           string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";
           DataTable sheets = GetSchemaTable(connStr);
           string sql = string.Empty;
           DataSet ds = new DataSet();
           foreach (DataRow dr in sheets.Rows)
           {  //Print_Area
               string WorkSheetName = dr["TABLE_NAME"].ToString().Trim();
               if (!WorkSheetName.Contains("Print_Area"))
               {
                   sql = "SELECT * FROM [" + WorkSheetName + "]";
                   ds.Clear();
                   OleDbDataAdapter data = new OleDbDataAdapter(sql, connStr);
                   data.Fill(ds);
                   DataTable dt1 = ds.Tables[0];
                   foreach (DataRow dr1 in dt1.Rows)
                   {
                       //parsing work
                   }
               }
           }
    
        static DataTable GetSchemaTable(string connectionString)
        {
            using (OleDbConnection connection = new
                       OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable schemaTable = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                return schemaTable;
            }
        }
