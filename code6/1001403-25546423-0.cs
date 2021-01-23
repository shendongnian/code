    using(SqlConnection sqlConn = new SqlConnection(connStr))
    using(SqlCommand cmd = sqlConn.CreateCommand() )
    {
       ...
       ...
       using(SqlDataReader reader = cmd.ExecuteReader())
       {
          ...
       }
    }
