    using(SqlConnection conn = new SqlConnection(getconnstring))
    {
        conn.Open();
        using(SqlCommand comm = new System.Data.SqlClient.SqlCommand(sqlstring,conn))
        {
            // ...
            using(SqlDataReader reader = comm.ExecuteReader())
            {
                // ...
            }
        }
    }
    
