    private string GetStateByZipCode(string ZipOrPostalCode, string ST)
    {
    try
    {
        string strServerName = ConfigurationManager.AppSettings["ServerName"];
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyNGConnect_ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "ngc_GetStateByZipCode";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ZipOrPostalCode", ZipOrPostalCode);
        cmd.Parameters.AddWithValue("@ST", ST);
        SqlDataReader reader = storedProcCommand.ExecuteReader();
        {
            while (reader.Read())
            {
                if (reader["ZipOrPostalCode"].ToString().Equals(ZipOrPostalCode) &&
                      reader["ST"].ToString().Equals(ST))
                {
                    ST = true;
                    break;
                }
            }
            con.Close ();
            reader.Close ();
            return ST;
        }
    }
    finally
    {
    }
