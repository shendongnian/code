    private void button1_Click(object sender, EventArgs e)
    {
        var builder = new SqlConnectionStringBuilder();
        builder.DataSource = "servername";
        builder.InitialCatalog = "databasename";
        builder.UserID = "username";
        builder.Password = "yourpassword";
        using(var conn = new SqlConnection(builder.ToString()))
        {
            using(var cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "select u_password from [user] where u_name = @u_name";
                cmd.Parameters.AddWithValue("@u_name", textBox1.Text);
                conn.Open();
                using(var reader = cmd.ExecuteReader())
                {
                     while (reader.Read())
                     {
                         var tmp = reader["u_password"];
                         if(tmp != DBNull.Value)
                         {
                             sifre = reader["u_password"].ToString();
                         }
                     }
                }
            }
        }
    }
