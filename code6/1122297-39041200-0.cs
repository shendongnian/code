    public bool TestConnection(string connString, List<string> databases) {
      using (context = new DatabaseContext(connString)) {
        if (!context.Database.Exists())
          return false;
        string query = "select * from master.sys.databases WHERE name NOT IN('master', 'tempdb', 'model', 'msdb')";
        var connection = context.Database.Connection;
        DataTable dt_databases = new DataTable();
        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection.ConnectionString);
        dataAdapter.Fill(dt_databases);
        // Getting name from each dataRow
        foreach (DataRow dr in dt_databases.Rows)
          databases.Add(dr.ItemArray[0].ToString());
        
        return true;
      }
    }
