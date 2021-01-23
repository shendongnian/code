    var sp = new SqlCommand("spInsertBloodGroup", conn)
    {
        CommandType = CommandType.StoredProcedure
    };
    sp.Parameters.Add("@ids", SqlDbType.Int, seqID);
    sp.Parameters.Add("@des", SqlDbType.NVarChar, Description);
    sp.Parameters.Add("@abbri", SqlDbType.NVarChar, Name);
    sp.Parameters.Add("@Datet", SqlDbType.Int, dateModed);
    sp.ExecuteNonQuery();
