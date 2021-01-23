    using(MySqlConnection con = new MySqlConnection(ConnectionString))
    using(MySqlCommand cmd = con.CreateCommand())
    {     
        cmd.CommandText = "Select * from books where Book_code = @code";
        cmd.Parameters.AddWithValue("@code", textBox2.Text);
        using(MySqlDataReader d2 = cmd.ExecuteReader())                   
        {
            while(d2.Read())
            {
                if (d2.GetString(0).ToLower() == textBox2.Text.ToLower())
                {
                     //
                }
            }
         }
        
    }
