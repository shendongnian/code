    using(SqlConnection Conn = new SqlConnection(connString))
    using(SqlCommand com = Conn.CreateCommand())
    {
        com.CommandText = "SELECT (Username) AS [User], (Password) as Pass FROM dbname WHERE Username = @user";
        com.Parameters.AddWithValue("@user", textBox1.Text);
        Conn.Open();
        using(SqlDataReader reader = com.ExecuteReader())
        {
           ...
        }
    }
