    public string  Sequence(Int32 userId)
    {
        //load the List one time to be used thru out the intire application
        var ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["EMSJConnectionString"].ConnectionString;
        using (SqlConnection connStr = new SqlConnection(ConnString))
        {
            using (SqlCommand cmd = new SqlCommand("get_LoginStatusQ", connStr))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Connection.Open();
                object result = cmd.ExecuteScalar();
                return result == null ? string.Empty : result.ToString()
            }
        }
    }
