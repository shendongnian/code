    using (SqlConnection conn = new SqlConnection("@"Data Source=admin\SQLEXPRESS;Initial Catalog=users;Integrated Security=True""))
    {
        string sqlString = "SELECT phone FROM userinfo WHERE username = @username AND password = @password";
        conn.Open();
        SqlCommand com = new SqlCommand(sqlString, conn);
        com.Paramaters.AddWithValue("@username", username);
        com.Parameters.AddWithValue("@password", password);
        
        using (SqlReader reader = com.ExecuteReader())
        {
        
            if (reader.HasRows)
            {
                TextBox3.Text = reader[0].ToString();
            }
        }
    }
