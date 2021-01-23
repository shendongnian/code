    using(SqlConnection conn = new SqlConnection(connStr))
    using(SqlCommand cmd = new SqlCommand(Sql, conn))
    {
        conn.Open();
        using(SqlDataReader DR = cmd.ExecuteReader())
        {
            // consume data
        }
    }
