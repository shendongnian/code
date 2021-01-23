    private void _loginButton_Click(object sender, EventArgs e)
    {
            string username = _usernameTextBox.Text;
            string password = HashPass(_passwordTextBox.Text);
            
            if (_login.LoginQuery(username, password))
            {
                _usernameTextBox.Text = String.Empty;
                _passwordTextBox.Text = String.Empty;
    
                MessageBox.Show("Login Success");
            }
            else
            {
                MessageBox.Show("Username/Password incorrect");
            }
    }
