    SqlConnection conn = new SqlConnection(connectionString);
    DataTable dt = new DataTable();
    string cmd = null;
    cmd = "select col1 from table";
    SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);
    conn.Open();
    adp.Fill(dt);
    conn.Dispose();
    if (dt.Rows.Count > 0) {
    	string b = Strings.Replace(dt.Rows(0)("col1"), " ", "");	
    }
