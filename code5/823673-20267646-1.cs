    int id = 123;
    string name = "abc";
    using (var conn = new SqlConnection(ConnectionString))
    {
        conn.Execute("Some TSQL", new { id, name });
    }
