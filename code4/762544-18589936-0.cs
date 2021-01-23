    public static IEnumerable<string> GetTables()
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            foreach (var table in connection.GetSchema("Tables").Rows)
            {
                yield return (string)table[2];
            }
        }
    }
