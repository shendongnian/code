    using(SqlConnection cnn = new SqlConnection(.....))
    using(SqlCommand cmd = new SqlCommand("StoredProcedure1", cnn))
    {
        cnn.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p = new SqlParameter("@oResult", SqlDbType.Int);
        p.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p);
        // Here the name @returnValue is arbitrary, you could call it whatever you like
        SqlParameter r = new SqlParameter("@returnValue", SqlDbType.Int);
        r.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(r);
        cmd.ExecuteNonQuery();
        int result = Convert.ToInt32(cmd.Parameters["@oResult"].Value);
        int returnValue = Convert.ToInt32(cmd.Parameters["@returnValue"].Value);
    }
