    using(SqlConnection cnn = new SqlConnection(.....))
    using(SqlCommand cmd = new SqlCommand("StoredProcedure1", cnn))
    {
        cnn.Open();
        SqlParameter p = new SqlParameter("@oResult", SqlDbType.Int);
        p.Direction = ParameterDirection.Output;
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(p);
        cmd.ExecuteNonQuery();
        int result = Convert.ToInt32(cmd.Parameters["@oResult"].Value);
    }
