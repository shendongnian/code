    using (SqlCommand cmd = new SqlCommand("select FirstName,LastName,MobileNumber,EmailAddress from Users,OtherInfo where OTID = USERID AND UserName=@UserName"))
    {
        cmd.Parameters.AddWithValue("UserName", UsrName); // Works correctly for this
        cmd.Connection = connection;
        connection.Open();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                info.FirstName = reader["FirstName"].ToString();
                info.LastName = reader["LastName"].ToString();
                info.TelNum = reader["MobileNumber"].ToString();
                info.Email = reader["EmailAddress"].ToString();
            }
        }
    }
