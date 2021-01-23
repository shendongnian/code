    protected void Login_Click(object sender, EventArgs e)
    {
        var result = Utilities.AuthenticateUser(txtUserName.Text, txtPassword.Text);
		if (result.Authenticated)
		{
			Session["AuthenticationResult"] = result;
			FormsAuthentication.RedirectFromLoginPage(result.Username, false);
		}
    }
	
