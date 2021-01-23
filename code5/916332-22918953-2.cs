    protected void btnLogin_Click(object sender, EventArgs e)
    {
       if (AuthenticateUser(txtEmail.Text, txtPassword.Text))
       {
          // Thus all you need
          FormsAuthentication.RedirectFromLoginPage(username, true);
       }
    }
