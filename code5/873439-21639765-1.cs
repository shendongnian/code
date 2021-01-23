    using(SqlConnection conn = getAWorkingDbConnection())
    using (SqlCommand sqlCmd = new SqlCommand("SELECT * FROM GlassTable", conn))
    {
        sqlCmd.CommandTimeout = 0;
        conn.Open();
        using (SqlDataReader dataReader = sqlCmd.ExecuteReader())
        {
            while (dataReader.Read())
            { 
                // do something useful ...
            }
        }
        sqlCmd.CommandText = "DROP TABLE GlassTable";
        sqlCmd.ExecuteNonQuery();
    }
