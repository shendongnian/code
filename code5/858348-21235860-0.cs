    public static List<string> GetAllQueriesFromDataBase()
    {
        var queries = new List<string>();
        using (var con = new OleDbConnection(Connection.connectionString()))
        {
            con.Open();
            var dt = con.GetSchema("Views");
            queries = dt.AsEnumerable().Select(dr => dr.Field<string>("TABLE_NAME")).ToList();
        }
        return queries;
    }
