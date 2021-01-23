    public function(Data dt)
    {
        con = new SqlConnection(constring);
        
        cmd = new SqlCommand("pro100", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@brand", dt.brand);
        cmd.Parameters.Add("@check", SqlDbType.Int).Direction = ParameterDirection.Output;
        con.Open();
        cmd.ExecuteNonQuery();   
        int result = Convert.ToInt32(cmd.Parameters["@check"].Value);
        con.Close();
        return result;
    }
