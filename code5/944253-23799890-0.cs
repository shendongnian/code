    private void goSignIn_Click(object sender, EventArgs e)
    {
      var loggedInCustomer =LoginController.signIn(usernameBox.Text, passwordBox.Text);
      if (loggedInCustomer == null)
      {
         MessageBox.Show("Wrong username or password! :( ", "Wrong!");
      }
      else
      {
         Close();
      }
    }
