    void AssignValue()
    {
        using(MySqlConnection con =new MySqlConnection("/*connection string here*/"))
        using(MySqlCommand command = new MySqlCommand("SELECT rol FROM users WHERE 
                                     user = @user",con))
        {
          con.Open();
          command.Parameters.AddWithValue("@user",txtUser.Text);        
          TextBox2.Text = commad.ExecuteScalar().ToString();        
        }
    }
