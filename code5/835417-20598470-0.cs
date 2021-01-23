      public DataRow GetResultsTable(string Username)
    {
    using (SqlDatabaseClient client = SqlDatabaseManager.GetClient())
    {
        DataRow row = client.ExecuteQueryRow("SELECT * FROM users WHERE username = '" + Username + "'");
        
        DataRow dr = new DataRow;
        dr.Columns.Add("Username".ToString());
        dr.Columns.Add("Motto".ToString());
        dr.Columns.Add("Email".ToString());
        dr.Columns.Add("Homeroom".ToString());
        dr.Columns.Add("Health".ToString());
        dr.Columns.Add("Energy".ToString());
        dr.Columns.Add("Age".ToString());
        dr["Username"] = "" + row["username"] + "";
        dr["Motto"] = "" + row["motto"] + "";
        dr["Email"] = "" + row["mail"] + "";
        dr["Homeroom"] = "" + row["home_room"] + "";
        dr["Health"] = "" + row["health"] + "";
        dr["Energy"] = "" + row["energy"] + "";
        dr["Age"] = "" + row["age"] + "";
        
        return dr;
    }
     }
        SqlDatabaseManager.Initialize();
        DataTable table = new DataTable();
        table.Columns.Add("Username".ToString());
        table.Columns.Add("Motto".ToString());
        table.Columns.Add("Email".ToString());
        table.Columns.Add("Homeroom".ToString());
        table.Columns.Add("Health".ToString());
        table.Columns.Add("Energy".ToString());
        table.Columns.Add("Age".ToString());
        using (SqlDatabaseClient client  = SqlDatabaseManager.GetClient())
        foreach (DataRow row2 in client.ExecuteQueryTable("SELECT * FROM users").Rows)
      {
      table .Rows.Add( GetResultsTable((string)row2["username"]));
       }
      DataGridView.DataSourse=table ;
