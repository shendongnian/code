    public DataTable GetDeity()
    {
        using(SqlConnection sqlConn = new SqlConnection(conSTR))
        using(SqlCommand cmd = new SqlCommand("get_DeityMaster", sqlConn))
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlConn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
    }
