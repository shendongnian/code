    public function(Data dt)
    {
        con = new SqlConnection(constring);
        string brand = dt.brand;
        cmd = new SqlCommand("pro100", con);
        cmd.CommandType = CommandType.StoredProcedure;
    
        SqlParameter param = new SqlParameter("@check", SqlDbType.Int);
        param.Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@brand", brand);
        cmd.Parameters.Add(param);
        con.Open();
        cmd.ExecuteNonQuery();
   
        int result = Convert.ToInt32(cmd.Parameters["@check"].Value);
        con.Close();
        return result;
    }
