    public function(Data dt)
    {
        con = new SqlConnection(constring);
        string brand = dt.brand;
        cmd = new SqlCommand("execute pro100", con);
    
        SqlParameter param = new SqlParameter("@check", SqlDbType.Int);
        param.Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@brand", brand);
        cmd.Parameters.Add(param);
        con.Open();
        cmd.ExecuteNonQuery();
    
        int? result = (int?)param.Value; // Exception was here
        con.Close();
        return result;
    }
