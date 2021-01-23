    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["registerCS"].ConnectionString))
    {
        connection.Open();
        string sql1 = "Select pemgrp from Profile where userID = @username";
        string sql = "Select studname from Profile where pemgrp IN (" + sql1 + ")";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@username", Session["username"].ToString());
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            //
        }
    }
