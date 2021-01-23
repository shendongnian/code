    public static void insertTables(string path_from, string path_to, 
                                                                List<string> _tables)
    {
        string conString = ("Provider=Microsoft.JET.OLEDB.4.0;data source=" 
                                        + path_to + ";Persist Security Info=False;");
        OleDbConnection dbconn = new OleDbConnection(conString);
        dbconn.Open();
        OleDbCommand dbcommand = new OleDbCommand();
        _tables.ForEach(delegate(String name)
        {
            string selQuery = "SELECT f.* INTO " + name + " FROM " + name 
                                                   + " AS f IN '" + path_from + "';";
            dbcommand.CommandText = selQuery;
            dbcommand.CommandType = CommandType.Text;
            dbcommand.Connection = dbconn;
            int result = dbcommand.ExecuteNonQuery();
        });
        dbconn.Close();
    }
    insertTables(".\\one.mdb", ".\\another.mdb", NotFoundTables);
