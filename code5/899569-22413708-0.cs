    MySqlCommand myCommand = new MySqlCommand("Select count(*) from users where 
       user=@username and parola=@password", connection);
    myCommand.Parameters.AddWithValue("@username",txtUser.Text);
    myCommand.Parameters.AddWithValue("@pasword",txtParola.Text);
    int totalCount = Convert.ToInt32(myCommand.ExecuteScalar());
            
            if (totalCount > 0)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show("Nu ok");
            }
