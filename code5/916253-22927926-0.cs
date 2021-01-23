    private void loginButton_Click(object sender, EventArgs e)
    {
       // Check if the user haven't chosen an account
       if (comboBox1.Text == "") { return; }
       // Check if the password TextBox is empty
       if (textBox1.Text == "") { return; }
       // Create a new method for checking the account and password, which returns a bool
       bool loginSuccess = CheckUserInput(comboBox1.Text.Trim(), textBox1.Text);
    
       if (loginSuccess)
       {
          // Create a new instance of your user-interface form. Give the account name and password
          // to it's constructor
          UserForm newForm = new UserForm(comboBox1.Text.Trim(), textBox1.Text.Trim()))
          // Show the created UserForm form
          newForm.Show();
          // Close this login form
          this.Close();
       }
    }
