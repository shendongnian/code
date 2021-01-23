        SqlConnection conn = ...; // here your connection
        conn.Open();
        SqlCommand cmd = new SqlCommand("StoredProcedureName", conn)
        {
            CommandType = CommandType.StoredProcedure
        };
               
        cmd.Parameters.Add(new SqlParameter("@paramName", paramValue));
        SqlParameter retval = cmd.Parameters.Add("@returnValue", SqlDbType.Int); // assiming that the return type is an int
        retval.Direction = ParameterDirection.ReturnValue;
        cmd.ExecuteNonQuery();
        int result = (int)cmd.Parameters["@returnValue"].Value; // assuming is an int
            
            
