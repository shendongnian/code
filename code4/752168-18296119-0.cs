            cn.open
            MySqlDataAdapter LoginAdapter = new MySqlDataAdapter();
            dynamic CommandQuerry = @"SELECT * From users WHERE Username='" + UsernameField.Text + "'AND Password='" + PasswordField.Text + "';";
            MySqlCommand LoginCommand = new MySqlCommand(); //The Login Command
            MySqlDataReader LoginDataReader = default(MySqlDataReader); //Create a reader variable to check login details.
 
            if (cn.State == ConnectionState.Open)
            {
                  LoginCommand.Connection = SelectedSchoolDB;
                  LoginCommand.CommandText = CommandQuerry;
                  LoginAdapter.SelectCommand = LoginCommand;
                  LoginDataReader = LoginCommand.ExecuteReader();
        
                  if (Convert.ToInt32(LoginDataReader.HasRows) == 0)
                  {
                         DialogResult a = MessageBox.Show(@"Invalid username/password, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
                  else
                  {
                         LoginDataReader.Close(); // Close The reader
                         This.FormName.Hide(); //Close the login form
                         Newform.ShowDialog(); //Show the new form
                  }
    cn.close()
    }
