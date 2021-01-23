    string query = "Select * from books where Book_code=@BookCode";
                   
    cmd = new MySqlCommand(query, con);
    cmd.Parameters.AddWithValue("@BookCode", textBox2.Text);
    using(MySqlDataReader reader = cmd.ExecuteReader())                   
    {
         while(reader.Read())
         {
             if (reader.GetString(0).ToLower() == textBox2.Text.ToLower())
             {
             }
         }
     }
