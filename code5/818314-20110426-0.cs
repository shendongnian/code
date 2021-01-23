    using (SqlConnection c = new SqlConnection(cString))
    using (SqlCommand cmd = new SqlCommand("SP_RegisterComp", c))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CompName", compName);
        cmd.Parameters.AddWithValue("@Check_In", checkIn);
        var outParm = new SqlParameter("@ID", SqlDbType.Int);
        outParm.Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        var val = outParm.Value;
    }
