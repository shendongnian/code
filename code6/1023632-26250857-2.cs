    using(SqlConnection cnn = new SqlConnection(.....))
    using(SqlCommand cmd = new SqlCommand("StoredProcedure1", cnn))
    {
        cnn.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p = new SqlParameter("@oResult", SqlDbType.Int);
        p.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p);
        cmd.ExecuteNonQuery();
        int result = Convert.ToInt32(cmd.Parameters["@oResult"].Value);
    }
