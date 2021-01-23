	protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
	{
		if (IsValid)
		{
			if (FormsAuthentication.Authenticate(Login1.UserName, Login1.Password))
			{
				FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
			}
		}
	}
