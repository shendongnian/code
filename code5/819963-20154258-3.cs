    int result; 
    using (SqlConnection conn = new SqlConnection("hereYourConnectionString"))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("StoredProcedureName", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            // input parameters 
            cmd.Parameters.Add(new SqlParameter("@paramName", paramValue));
            // output parameters
            SqlParameter retval = cmd.Parameters.Add("@returnValue", SqlDbType.Int); // assiming that the return type is an int
            retval.Direction = ParameterDirection.ReturnValue;
           cmd.ExecuteNonQuery();
           result = (int)cmd.Parameters["@returnValue"].Value; // assuming is an int
        }               
    }
            
