    SqlCommand cmd = new SqlCommand("updatestudenthws", con);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@hwid", SqlDbType.Int);   // this needs to be SqlDbType.Int 
    cmd.Parameters.Add("@stdid", SqlDbType.NVarChar, 50);  // this should be SqlDbType.NVarChar and specify its proper length
    cmd.Parameters.Add("@grade", SqlDbType.Float);  // this needs to be SqlDbType.Float
