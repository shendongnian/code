    using (SqlConnection conn = new SqlConnection("@"Data Source=admin\SQLEXPRESS;Initial Catalog=users;Integrated Security=True""))
    {
        string sqlString = "UPDATE userinfo SET phone = @phone WHERE username = @username AND password = @password";
        conn.Open();
        SqlCommand com = new SqlCommand(sqlString, conn);
        com.Parameters.AddWithValue("@phone", TextBox3.Text);
        com.Paramaters.AddWithValue("@username", username);
        com.Parameters.AddWithValue("@password", password);
        
        com.ExecuteNonQuery();
    }
