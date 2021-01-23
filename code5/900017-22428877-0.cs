    void AssignValue()
    {
        MySqlConnection con = new MySqlConnection("/*connection string here*/");
        MySqlCommand command = new MySqlCommand("SELECT rol FROM users WHERE 
                                     user = @user",con);
        con.Open();
        command.Parameters.AddWithValue("@user",TextBox1.Text);        
        String rolName = commad.ExecuteScalar().ToString();   
        TextBox2.Text = roleName;     
        con.Close();        
    }
