    public int executeNonQueries(string query02)
    {
        long id = -1;
        SqlConnection con = null;
        SqlCommand com = null;
        try
        {
            con = new SqlConnection(DBConnect.makeConnection());
            con.Open();
            com = new SqlCommand(query02, con);
            SqlParameter returnParameter = com.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            com.ExecuteNonQuery();
            id = (int) returnParameter.Value;
        }
        catch (Exception ex)
        {
            id = -1;
            throw ex;
        }
        finally
        {
            com.Dispose();
            con.Close();
        }
        return id;
    }
