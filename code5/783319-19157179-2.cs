    using(SqlConnection cn = new SqlConnection(...))
    using(SqlCommand cmd = new SqlCommand(procName, cn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cn.Open()
        using(SqlDataAdapter da = new SqlDataAdapter(cmd)
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            // DataTable filled with the data returned by the last SELECT in your SP
            ......
        }    
    }
