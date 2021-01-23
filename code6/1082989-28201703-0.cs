    using(SqlCommand cmd = new SqlCommand(@"SELECT * FROM Logins 
                                         WHERE Username = @Username
                                           AND Password = @Password", connection);
    {
        cmd.Parameters.AddWithValue("@Username", txtuser.Text);
        cmd.Parameters.AddWithValue("@Password", security.AES(security.Hashstring(txtpass.Text)));
        using(SqlDataReader dr = cmd.ExecuteReader())
        {
             if (dr.Read())
             ....
        }
    }
