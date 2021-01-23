    private void btnLogin_Click(object sender, EventArgs e)
    {
        int numerror = 0;
        if (UsernameTextBox.Text == "")
        {
            ErrorLabel.Text = "*1 required field is blank.";
        }
        else if (PasswordTextBox.Text == "")
        {
            ErrorLabel.Text = "*2 required fields are blank";
        }
        else
        {
            string connectionString = "datasource=localhost;port=3306;username=*****;password=**********";
            string select = "SELECT username, password FROM userinfo.users " +
                            "WHERE username = @username";
            using (MySqlConnection Conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(select, Conn))
                {
                    cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text);
                    Conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader.GetString(0);
                            string password = reader.GetString(1);
                            string encodeduserinputpassword = EncodePassword(PasswordTextBox.Text);
                            if (password == encodeduserinputpassword)
                            {
                                AirSpace airspaceform = new AirSpace();
                                airspaceform.Show();
                                this.Hide();
                            }
                            else
                            {
                                CMessageBox("Login Error", "Incorrect username or password.");
                            }
                        }
                        else
                        {
                            CMessageBox("Login Error", "Incorrect username or password.");
                        }
                    }
                    Conn.Close();
                }
            }
        }
    }
