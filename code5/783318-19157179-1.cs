    using(SqlConnection cn = new SqlConnection(...))
    using(SqlCommand cmd = new SqlCommand(procName, cn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cn.Open()
        using(SqlDataReader r = cmd.ExecuteReader())
        {
            while(r.Read())
            {
                // read every row and use the field values .....
            }
    
        }    
    }
