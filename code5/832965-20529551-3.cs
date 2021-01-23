    private List<Foo> GetPrintedSsns(SqlConnection connection, DataTable table)
    {
        var foos = new List<Foo>();
        using (SqlCommand cmd = connection.CreateCommand())
        {
            cmd.CommandTimeout = configuration.CommandTimeout;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPrintedDocuments";
            var parameter = cmd.Parameters.AddWithValue("SsnList", table);
            parameter.SqlDbType = SqlDbType.Structured;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var foo = new Foo();
                    //Map properties to object
                    foos.Add(foo);
                }
            }
        }
        return foos;
    }
