    string connectionString = ConfigurationSettings.AppSettings["connectionstrings"];
            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            oledbConn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", oledbConn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
    foreach (DataRow row in dt.Rows)
    {
                       string EmployeeCode = row["EmployeeCode"].ToString();
    }
                      
