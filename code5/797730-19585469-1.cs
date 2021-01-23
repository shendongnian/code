    public DataTable GetDBDataTable(MySqlConnection dbconnection, string table, string columns = "*", string clause = "")
    {
        MySqlCommand mysqlcmd = new MySqlCommand("SELECT " + columns + " FROM " + table + " " + clause +";", dbconnection);
        MySqlDataAdapter mysqlad = new MySqlDataAdapter(mysqlcmd);
        DataSet ds = new DataSet();
        mysqlad.Fill(ds);
        DataTable dt = ds.Tables[0];
        return dt;
    }
