    public void InsertClubRoles(int RoleID, string Roledesc, string Createdby)
    {
        using (SqlCommand cmdclubroles = new SqlCommand()) 
        {
            // get stored procedure
            cmdclubroles.CommandText = "usp_insertrlubroles";
            cmdclubroles.CommandType = CommandType.StoredProcedure;     
            // connection
            cmdclubroles.Connection = jadcoreConnection.GetConnection();
            // parameters
            cmdclubroles.Parameters.AddWithValue("@RoleID", Convert.ToInt32(RoleID));
            cmdclubroles.Parameters.AddWithValue("@Roledesc", Roledesc);
            cmdclubroles.Parameters.AddWithValue("@Createdby", Createdby);
            // execute the INSERT statement
            cmdclubroles.Connection.Open();
            cmdclubroles.ExecuteNonQuery();
            cmdclubroles.Connection.Close();
        }
    }
