    lock (_lockObj)
    {
        using (SqlConnection c = new SqlConnection(cString))
        using (SqlTransaction tran = c.BeginTransaction())
        using (SqlCommand cmd = new SqlCommand("SP_RegisterComp", c, tran))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompName", compName);
            cmd.Parameters.AddWithValue("@Check_In", checkIn);
            var outParm = new SqlParameter("@ID", SqlDbType.Int);
            outParm.Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            // commit the transaction
            tran.Commit();
            var val = outParm.Value;
        }
    }
